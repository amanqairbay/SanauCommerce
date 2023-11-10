using Basket.Application.GrpcServices;
using Basket.Application.Handlers;
using Basket.Application.Mappers;
using Basket.Core.Repositories;
using Basket.Infrastructure.Repositories;
using Discount.Grpc.Protos;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

namespace Basket.API.Extensions;

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
        builder.Services.AddAutoMapper(typeof(BasketProfile));
        builder.Services.AddScoped<IBasketRepository, BasketRepository>();
        builder.Services.AddScoped<DiscountGrpcService>();
        builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(opt => opt.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]!));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateBasketHandler).Assembly));
        builder.Services.AddSwaggerGen(opt => opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket.API", Version = "v1" }));
        builder.Services.AddStackExchangeRedisCache(options => { options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString"); });
        builder.Services.AddHealthChecks().AddRedis(builder.Configuration["CacheSettings:ConnectionString"]!, "Redis Health", HealthStatus.Degraded);
        builder.Services.AddControllers();
        
        return builder;
    } 
}