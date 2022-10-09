using Microsoft.Extensions.Options;

namespace WorkerService.CleanArchitecture.Options;

public class CreateToDoWorkerOptionsSetup : IConfigureOptions<CreateToDoWorkerOptions>
{
    private const string ConfigurationSectionName = "CreateToDoWorkerOptions";
    private readonly IConfiguration _configuration;

    public CreateToDoWorkerOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(CreateToDoWorkerOptions options)
    {
        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}
