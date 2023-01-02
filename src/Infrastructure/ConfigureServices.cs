using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid.Extensions.DependencyInjection;
using WorkerService.CleanArchitecture.Application.Common.Interfaces;
using WorkerService.CleanArchitecture.Application.Services;
using WorkerService.CleanArchitecture.Infrastructure.Communication;
using WorkerService.CleanArchitecture.Infrastructure.Communication.Options;
using WorkerService.CleanArchitecture.Infrastructure.Persistence;
using WorkerService.CleanArchitecture.Infrastructure.Persistence.Interceptors;
using WorkerService.CleanArchitecture.Infrastructure.Queues.Options;
using WorkerService.CleanArchitecture.Infrastructure.Services;

// ReSharper disable CheckNamespace

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
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
            SendgridOptions? sendgridOptions = services.BuildServiceProvider()
                .GetRequiredService<IOptions<SendgridOptions>>()
                .Value;

            options.ApiKey = sendgridOptions.ApiKey;
        });

        services.AddMassTransit(options =>
        {
            options.AddConsumer<SendEmailConsumer>();
            options.SetKebabCaseEndpointNameFormatter();

            options.UsingRabbitMq((context, cfg) =>
            {
                RabbitMqOptions? opt = services.BuildServiceProvider()
                    .GetRequiredService<IOptions<RabbitMqOptions>>()
                    .Value;

                cfg.Host(opt.HostName, opt.VirtualHost, h =>
                {
                    h.Username(opt.UserName);
                    h.Password(opt.Password);
                });

                cfg.UseMessageRetry(r => r.Immediate(opt.MaxMessageRetryCount));

                cfg.ConfigureEndpoints(context);
            });
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<ApplicationDbContextInitialiser>();
        services.AddScoped<ISendgridService, SendgridService>();

        services.AddTransient<IDateTime, DateTimeService>();

        return services;
    }
}