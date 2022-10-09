using MediatR;

namespace WorkerService.CleanArchitecture.Workers;

public abstract class WorkerBase : BackgroundService
{
    protected ILogger<WorkerBase> Logger { get; }
    protected ISender Mediator { get; }
    
    protected WorkerBase(ILogger<WorkerBase> logger, ISender mediator)
    {
        Logger = logger;
        Mediator = mediator;
    }
}