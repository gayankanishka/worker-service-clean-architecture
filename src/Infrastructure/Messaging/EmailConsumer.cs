using MassTransit;
using Microsoft.Extensions.Logging;
using WorkerService.CleanArchitecture.Application.Common.Interfaces;
using WorkerService.CleanArchitecture.Domain.Models;

namespace WorkerService.CleanArchitecture.Infrastructure.Messaging;

public class EmailConsumer : IConsumer<EmailPayload>
{
    private readonly ILogger<EmailConsumer> _logger;
    private readonly ISendgridService _sendgridService;

    public EmailConsumer(ILogger<EmailConsumer> logger, ISendgridService sendgridService)
    {
        _logger = logger;
        _sendgridService = sendgridService;
    }

    public async Task Consume(ConsumeContext<EmailPayload> context)
    {
        _logger.LogInformation("Message processing: " + context.CorrelationId);

        await _sendgridService.SendMailAsync(context.Message);
    }
}