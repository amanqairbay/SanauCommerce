using Catalog.Application.Handlers;
using Catalog.Core.Logging;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Logging;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Catalog.API.Extensions;

public static class ServiceExtensions
{
    // CORS 
    public static void AddCorsConfigure(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

    // MesiatR
    public static void AddMediatrConfigure(this IServiceCollection services) =>
        services.AddMediatR(configuration => 
            configuration.RegisterServicesFromAssembly(typeof(CreateProductHandler).Assembly));

    // Health Checks
    public static void AddHealthChecksConfigure(this IServiceCollection services, IConfiguration configuration) =>
        services.AddHealthChecks().AddMongoDb(
            configuration["Databasesetting:ConnectionString"]!, "Catalog Mongo Db Health Check", HealthStatus.Degraded);
    
    // Logging
    public static void AddLoggerConfigure(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    // Repository manager
    public static void AddRepositoryManagerConfigure(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

}