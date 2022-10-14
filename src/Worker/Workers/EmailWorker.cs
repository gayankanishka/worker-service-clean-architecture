using WorkerService.CleanArchitecture.Domain.Models;

namespace WorkerService.CleanArchitecture.Workers;

public class EmailWorker : WorkerBase
{
    public EmailWorker(ILogger<EmailWorker> logger) 
        : base(logger)
    {
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}