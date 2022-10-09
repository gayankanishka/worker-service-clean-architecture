using MediatR;
using Microsoft.Extensions.Options;
using WorkerService.CleanArchitecture.Options;

namespace WorkerService.CleanArchitecture.Workers;

internal abstract class WorkerBase<T> : BackgroundService
{
    protected ILogger<WorkerBase<T>> Logger { get; }
    protected IMediator Mediator { get; }
    protected WorkerOptions Options { get; }

    protected WorkerBase(ILogger<WorkerBase<T>> logger,
        IMediator mediator,
        IOptions<WorkerOptions> options)
    {
        Logger = logger;
        Mediator = mediator;
        Options = options.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Logger.LogInformation("XIA.Worker service starting at: {time}", DateTimeOffset.Now);
        
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(Options.DelayMilliseconds, stoppingToken);
        }
    }
    
    protected abstract Task ProcessMessage(T message, string messageId, 
        IReadOnlyDictionary<string, object> userProperties, CancellationToken cancellationToken);
}