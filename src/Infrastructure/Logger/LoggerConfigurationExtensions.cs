using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace WorkerService.CleanArchitecture.Infrastructure.Logger;

public static class LoggerConfigurationExtensions
{
    public static void SetupLoggerConfiguration(string appName)
    {
        Log.Logger = new LoggerConfiguration()
            .ConfigureBaseLogging(appName)
            .CreateLogger();
    }

    public static LoggerConfiguration ConfigureBaseLogging(this LoggerConfiguration loggerConfiguration, string appName)
    {
        loggerConfiguration
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .WriteTo.Async(a => a.Console(theme: AnsiConsoleTheme.Code))
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithThreadId()
            .Enrich.WithProperty("ApplicationName", appName);

        return loggerConfiguration;
    }
}