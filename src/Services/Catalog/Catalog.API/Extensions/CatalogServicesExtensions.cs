using Catalog.Application.Contracts.Persistence;
using Catalog.Application.Features.Products.Commands.CreateProduct;
using Catalog.Domain.Logging;
using Catalog.Infrastructure.Logging;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Catalog.API.Extensions;

public static class CatalogServicesExtensions
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
            configuration.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly));

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

    // Identity
    public static void AddIdentityConfigure(this IServiceCollection services) 
    {
        services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options => 
                {
                    options.Authority = "https://localhost:5005";
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters{ ValidateAudience = false };
                });
    }
}