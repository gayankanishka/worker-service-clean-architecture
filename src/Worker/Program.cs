using Serilog;
using WorkerService.CleanArchitecture.Infrastructure.Logger;
using WorkerService.CleanArchitecture.Options;
using LoggerConfigurationExtensions = WorkerService.CleanArchitecture.Infrastructure.Logger.LoggerConfigurationExtensions;

string applicationName = "WorkerService-CleanArchitecture";

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging =>
    {
        LoggerConfigurationExtensions.SetupLoggerConfiguration(applicationName);
    })
    .ConfigureServices(services =>
    {
        services.ConfigureOptions<WorkerOptions>();
        
        // All the Worker processor registrations
        // services.AddHostedService<Worker>();
    })
    .UseSerilog(((hostBuilderContext, services, loggerConfiguration) => 
    { 
        loggerConfiguration.ConfigureBaseLogging(applicationName);
    }))
    .Build();

await host.RunAsync();
