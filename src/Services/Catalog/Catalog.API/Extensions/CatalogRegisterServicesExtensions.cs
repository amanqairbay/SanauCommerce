using System.Reflection;
using Catalog.API.Middlewares;
using Catalog.Application.Behaviours;
using Catalog.Application.Mappers;
using Catalog.Core.Services;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Services;
using FluentValidation;
using MediatR;
using NLog;

namespace Catalog.API.Extensions;

/// <summary>
/// Represents a registry of services extensions.
/// </summary>
public static class CatalogRegisterServicesExtensions
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
        builder.Services.AddTransient<CatalogExceptionHandlingMiddleware>();
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CatalogValidationBehaviour<,>));
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Services.AddLoggerConfigure();
        builder.Services.AddScoped<ICatalogContext, CatalogContext>();
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddRepositoryManagerConfigure();
        builder.Services.AddHealthChecksConfigure(builder.Configuration);
        builder.Services.AddIdentityConfigure();
        builder.Services.AddSwaggerConfigure();
        builder.Services.AddControllers();
        
        return builder;
    }
}