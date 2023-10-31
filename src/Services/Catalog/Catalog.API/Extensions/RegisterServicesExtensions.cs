using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

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
        builder.Services.AddApiVersioning();
        builder.Services.AddAutoMapper(typeof(CatalogProfile));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductHandler).Assembly));
        builder.Services.AddScoped<ICatalogContext, CatalogContext>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddHealthChecks().AddMongoDb(builder.Configuration["Databasesetting:ConnectionString"]!, "Catalog Mongo Db Health Check", HealthStatus.Degraded);
        builder.Services.AddSwaggerGen(opt => opt.SwaggerDoc("v1", new OpenApiInfo{ Title = "Catalog.API", Version = "v1" }));

        builder.Services.AddControllers();
        
        return builder;
    }
}