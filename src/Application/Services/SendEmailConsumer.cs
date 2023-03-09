using MassTransit;
using Microsoft.Extensions.Logging;
using WorkerService.CleanArchitecture.Application.Common.Interfaces;
using WorkerService.CleanArchitecture.Domain.Messages;

namespace WorkerService.CleanArchitecture.Application.Services;

public class SendEmailConsumer : IConsumer<SendEmailMessage>
{
    private readonly ILogger<SendEmailConsumer> _logger;
    private readonly ISendgridService _sendgridService;

    public SendEmailConsumer(ILogger<SendEmailConsumer> logger, ISendgridService sendgridService)
    {
        _logger = logger;
        _sendgridService = sendgridService;
    }

    public async Task Consume(ConsumeContext<SendEmailMessage> context)
    {
        _logger.LogInformation("Message processing: " + context.Message.MessageId);

        await _sendgridService.SendMailAsync(context.Message.EmailPayload);
    }
}