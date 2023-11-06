using Discount.Application.Handlers;
using Discount.Application.Mappers;
using Discount.Core.Repositories;
using Discount.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

namespace Discount.API.Extensions;

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
        builder.Services.AddAutoMapper(typeof(DiscountProfile));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateDiscountHandler).Assembly));
        builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
        builder.Services.AddSwaggerGen(opt => opt.SwaggerDoc("v1", new OpenApiInfo{ Title = "Discount.API", Version = "v1" }));
        builder.Services.AddHealthChecks().AddNpgSql(builder.Configuration["DatabaseSettings:ConnectionString"]!);

        builder.Services.AddControllers();

        return builder;
    }
}