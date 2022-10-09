using Microsoft.Extensions.Options;

namespace WorkerService.CleanArchitecture.Options;

public class WorkerOptionsSetup : IConfigureOptions<WorkerOptions>
{
    private const string ConfigurationSectionName = "WorkerOptions";
    private readonly IConfiguration _configuration;

    public WorkerOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(WorkerOptions options)
    {
        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}
