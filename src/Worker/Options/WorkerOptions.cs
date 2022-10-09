namespace WorkerService.CleanArchitecture.Options;

public class WorkerOptions
{
    public int DelayMilliseconds { get; init; }
    public string QueueName { get; init; }
}