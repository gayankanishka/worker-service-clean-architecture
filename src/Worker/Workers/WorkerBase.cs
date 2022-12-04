namespace WorkerService.CleanArchitecture.Workers;

public abstract class WorkerBase : BackgroundService
{
    protected WorkerBase(ILogger<WorkerBase> logger)
    {
        Logger = logger;
    }

    protected ILogger<WorkerBase> Logger { get; }
}