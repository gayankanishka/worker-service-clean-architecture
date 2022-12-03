using MassTransit;
using Microsoft.Extensions.Logging;
using WorkerService.CleanArchitecture.Domain.Models;

namespace WorkerService.CleanArchitecture.Infrastructure.Messaging;

public class EmailConsumer : IConsumer<EmailPayload>
{
    private readonly ILogger<EmailConsumer> _logger;

    public EmailConsumer(ILogger<EmailConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<EmailPayload> context)
    {
        _logger.LogInformation(context.Message.Body);
    }
}