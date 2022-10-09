using MediatR;
using Microsoft.Extensions.Options;
using WorkerService.CleanArchitecture.Options;

namespace WorkerService.CleanArchitecture.Workers;

public class CreateToDoWorker : WorkerBase
{
    private readonly CreateToDoWorkerOptions _options;
    
    public CreateToDoWorker(ILogger<CreateToDoWorker> logger,
        ISender mediator,
        IOptions<CreateToDoWorkerOptions> options) 
        : base(logger, mediator)
    {
        _options = options.Value;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(_options.DelayMilliseconds, stoppingToken);
        }
    }
}