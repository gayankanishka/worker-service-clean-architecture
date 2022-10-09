namespace WorkerService.CleanArchitecture.Options;

public class CreateToDoWorkerOptions
{
    public int DelayMilliseconds { get; init; }
    public string QueueName { get; init; }
}