namespace WorkerService.CleanArchitecture.Options;

public class EmailWorkerOptions
{
    public int DelayMilliseconds { get; init; }
    public string QueueName { get; init; }
    public string DeadLetterQueueName { get; init; }
    public string PoisonQueueName { get; init; }
    public int RetryCount { get; init; }
}
