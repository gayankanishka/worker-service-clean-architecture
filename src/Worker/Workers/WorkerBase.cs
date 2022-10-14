namespace WorkerService.CleanArchitecture.Workers;

public abstract class WorkerBase : BackgroundService
{
    protected ILogger<WorkerBase> Logger { get; }
    
    protected WorkerBase(ILogger<WorkerBase> logger)
    {
        Logger = logger;
    }
}