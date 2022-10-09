using Serilog;
using WorkerService.CleanArchitecture.Infrastructure.Logger;
using WorkerService.CleanArchitecture.Options;
using WorkerService.CleanArchitecture.Workers;
using LoggerConfigurationExtensions = WorkerService.CleanArchitecture.Infrastructure.Logger.LoggerConfigurationExtensions;

const string applicationName = "WorkerService-CleanArchitecture";

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging =>
    {
        LoggerConfigurationExtensions.SetupLoggerConfiguration(applicationName);
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.ConfigureOptions<CreateToDoWorkerOptionsSetup>();
        
        services.AddApplicationServices();
        services.AddInfrastructureServices(hostContext.Configuration);
        
        // All the Worker processor registrations
        services.AddHostedService<CreateToDoWorker>();
        services.AddHostedService<EmailWorker>();
    })
    .UseSerilog(((hostBuilderContext, services, loggerConfiguration) => 
    { 
        loggerConfiguration.ConfigureBaseLogging(applicationName);
    }))
    .Build();

await host.RunAsync();
