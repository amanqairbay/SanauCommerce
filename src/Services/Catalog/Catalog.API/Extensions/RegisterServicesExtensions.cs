using Catalog.Application.Mappers;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using NLog;

namespace Catalog.API.Extensions;

/// <summary>
/// Represents a registry of services extensions.
/// </summary>
public static class RegisterServicesExtensions
{
    /// <summary>
    /// Configures services.
    /// </summary>
    /// <param name="builder">A builder for web applications and services.</param>
    /// <returns>
    /// Returns a configured WebApplicationBuilder.
    /// </returns>
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        
        builder.Services.AddCorsConfigure();
        builder.Services.AddApiVersioning();
        builder.Services.AddAutoMapper(typeof(CatalogProfile));
        builder.Services.AddMediatrConfigure();
        builder.Services.AddLoggerConfigure();
        builder.Services.AddScoped<ICatalogContext, CatalogContext>();
        builder.Services.AddRepositoryManagerConfigure();
        builder.Services.AddHealthChecksConfigure(builder.Configuration);
        builder.Services.AddSwaggerConfigure();
        builder.Services.AddControllers();
        
        return builder;
    }
}