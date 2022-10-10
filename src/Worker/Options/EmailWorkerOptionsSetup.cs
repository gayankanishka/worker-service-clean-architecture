using Microsoft.Extensions.Options;

namespace WorkerService.CleanArchitecture.Options;

public class EmailWorkerOptionsSetup : IConfigureOptions<EmailWorkerOptions>
{
    private const string ConfigurationSectionName = "EmailWorkerOptions";
    private readonly IConfiguration _configuration;

    public EmailWorkerOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(EmailWorkerOptions options)
    {
        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}
