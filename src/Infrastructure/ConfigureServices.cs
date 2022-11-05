using WorkerService.CleanArchitecture.Application.Common.Interfaces;
using WorkerService.CleanArchitecture.Infrastructure.Persistence;
using WorkerService.CleanArchitecture.Infrastructure.Persistence.Interceptors;
using WorkerService.CleanArchitecture.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid.Extensions.DependencyInjection;
using WorkerService.CleanArchitecture.Infrastructure.Communication;
using WorkerService.CleanArchitecture.Infrastructure.Communication.Options;
using WorkerService.CleanArchitecture.Infrastructure.Messaging;
using WorkerService.CleanArchitecture.Infrastructure.Messaging.Options;

// ReSharper disable CheckNamespace

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureOptions<RabbitMqOptionsSetup>();
        services.ConfigureOptions<SendgridOptionsSetup>();

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("WorkerService.CleanArchitectureDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
        
        services.AddSendGrid(options =>
        {
            var sendgridOptions = services.BuildServiceProvider()
                .GetRequiredService<IOptions<SendgridOptions>>()
                .Value;
            
            options.ApiKey = sendgridOptions.ApiKey;
        });
        
        services.AddSingleton<IRabbitMqService, RabbitMqService>();        
        services.AddSingleton<IQueueService, QueueService>();
        
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<ApplicationDbContextInitialiser>();
        
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<ISendgridService, SendgridService>();

        return services;
    }
}
