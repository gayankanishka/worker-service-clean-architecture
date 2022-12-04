namespace WorkerService.CleanArchitecture.Infrastructure.Queues.Options;

public class RabbitMqOptions
{
    public string HostName { get; init; }
    public string VirtualHost { get; init; }
    public string UserName { get; init; }
    public string Password { get; init; }
    public int MaxMessageRetryCount { get; init; }
}