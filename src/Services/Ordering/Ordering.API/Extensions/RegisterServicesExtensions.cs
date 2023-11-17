using Microsoft.OpenApi.Models;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Persistence;

namespace Ordering.API.Extensions;

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
        builder.Services.AddApiVersioning();
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddSwaggerGen(opt => opt.SwaggerDoc("v1", new OpenApiInfo{ Title = "Ordering.API", Version = "v1" }));
        builder.Services.AddHealthChecks().Services.AddDbContext<OrderContext>();

        builder.Services.AddControllers();
        
        return builder;
    }
}