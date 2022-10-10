namespace WorkerService.CleanArchitecture.Options;

public class EmailWorkerOptions
{
    public int DelayMilliseconds { get; init; }
    public string QueueName { get; init; }
}