namespace WorkerService.CleanArchitecture.Infrastructure.Communication.Options;

public class SendgridOptions
{
    public string ApiKey { get; init; }
    public string FromEmail { get; init; }
    public string FromUser { get; init; }
    public bool SandboxMode { get; init; }
}