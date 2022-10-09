using MediatR;

namespace WorkerService.CleanArchitecture.Workers;

public class EmailWorker : WorkerBase
{
    public EmailWorker(ILogger<EmailWorker> logger, ISender mediator) 
        : base(logger, mediator)
    {
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}