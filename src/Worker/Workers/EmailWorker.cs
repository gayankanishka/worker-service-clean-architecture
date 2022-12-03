using MassTransit;
using WorkerService.CleanArchitecture.Domain.Models;

namespace WorkerService.CleanArchitecture.Workers;

public class EmailWorker : WorkerBase
{
    private readonly IBus _bus;

    public EmailWorker(ILogger<EmailWorker> logger, IBus bus) 
        : base(logger)
    {
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _bus.Publish(new EmailPayload(){Body = "test body"});
            
            await Task.Delay(5000, stoppingToken);
        }
    }
}