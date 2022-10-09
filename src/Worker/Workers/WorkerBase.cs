using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using MediatR;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using XIA.Worker.Settings;

namespace XIA.Worker.Workers;

internal abstract class WorkerBase<T> : BackgroundService
{
    private readonly ServiceBusClient _serviceBusClient;
    protected ILogger<WorkerBase<T>> Logger { get; }
    protected IMediator Mediator { get; }
    protected WorkerSettingsBase Settings { get; }

    protected WorkerBase(ILogger<WorkerBase<T>> logger,
        IMediator mediator,
        IOptions<WorkerSettingsBase> settings,
        IAzureClientFactory<ServiceBusClient> serviceBusFactory)
    {
        Logger = logger;
        Mediator = mediator;
        Settings = settings.Value;
        _serviceBusClient = serviceBusFactory.CreateClient("xia");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Logger.LogInformation("XIA.Worker service starting at: {time}", DateTimeOffset.Now);

        var messageProcessor = _serviceBusClient.CreateProcessor(Settings.QueueName);
        messageProcessor.ProcessMessageAsync += HandleMessageAsync;
        messageProcessor.ProcessErrorAsync += HandleErrorAsync;
        
        Logger.LogInformation($"Starting message pump on queue {Settings.QueueName} in namespace {messageProcessor.FullyQualifiedNamespace}");
        await messageProcessor.StartProcessingAsync(stoppingToken);
        Logger.LogInformation("Message pump started");

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(Settings.DelayMilliseconds, stoppingToken);
        }

        Logger.LogInformation("Stopping message pump");
        await messageProcessor.CloseAsync(cancellationToken: stoppingToken);
        Logger.LogInformation($"Message pump at queue {Settings.QueueName} stopped at: {DateTimeOffset.UtcNow}");
        Logger.LogInformation("XIA.Worker service stopping at: {time}", DateTimeOffset.Now);
    }
    
    protected abstract Task ProcessMessage(T message, string messageId, 
        IReadOnlyDictionary<string, object> userProperties, CancellationToken cancellationToken);

    private async Task HandleMessageAsync(ProcessMessageEventArgs arg)
    {
        try
        {
            string rawMessageBody = Encoding.UTF8.GetString(arg.Message.Body);
            Logger.LogInformation("Received message {MessageId} with body {MessageBody}",
                arg.Message.MessageId, rawMessageBody);

            var message = JsonSerializer.Deserialize<T>(rawMessageBody);

            await ProcessMessage(message, arg.Message.MessageId, arg.Message.ApplicationProperties, 
                arg.CancellationToken);
            Logger.LogInformation("Message {MessageId} processed", arg.Message.MessageId);

            await arg.CompleteMessageAsync(arg.Message);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Unable to handle message");
        }
    }
    
    private Task HandleErrorAsync(ProcessErrorEventArgs arg)
    {
        Logger.LogError(arg.Exception, "Unable to process message");
        return Task.CompletedTask;
    }
}