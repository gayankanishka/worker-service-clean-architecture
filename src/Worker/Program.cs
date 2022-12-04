using Serilog;
using WorkerService.CleanArchitecture.Infrastructure.Logger;
using LoggerConfigurationExtensions =
    WorkerService.CleanArchitecture.Infrastructure.Logger.LoggerConfigurationExtensions;

const string applicationName = "WorkerService-CleanArchitecture";

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging =>
    {
        LoggerConfigurationExtensions.SetupLoggerConfiguration(applicationName);
    })
    .ConfigureServices((hostContext, services) =>
    {
        // configure worker options

        services.AddApplicationServices();
        services.AddInfrastructureServices(hostContext.Configuration);

        // All the Worker processor registrations
    })
    .UseSerilog((hostBuilderContext, services, loggerConfiguration) =>
    {
        loggerConfiguration.ConfigureBaseLogging(applicationName);
    })
    .Build();

await host.RunAsync();