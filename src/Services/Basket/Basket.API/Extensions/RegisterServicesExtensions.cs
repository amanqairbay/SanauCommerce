using Basket.Application.GrpcServices;
using Basket.Application.Handlers;
using Basket.Application.Mappers;
using Basket.Core.Repositories;
using Basket.Infrastructure.Repositories;
using Discount.Grpc.Protos;
using MassTransit;
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
        // api versioning
        builder.Services.AddApiVersioning();
        // automapper
        builder.Services.AddAutoMapper(typeof(BasketProfile));
        // DI
        builder.Services.AddScoped<IBasketRepository, BasketRepository>();
        // gRPC
        builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options => options.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]!));
        builder.Services.AddScoped<DiscountGrpcService>();
        // mass transit rabbitmq
        builder.Services.AddMassTransit(config => { config.UsingRabbitMq((context, configuration) => { configuration.Host(builder.Configuration["EventBusSettings:HostAddress"]); }); });
        // mediatr
        builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateBasketHandler).Assembly));
        // swagger
        builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket.API", Version = "v1" }));
        // redis
        builder.Services.AddStackExchangeRedisCache(options => { options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString"); });
        builder.Services.AddHealthChecks().AddRedis(builder.Configuration["CacheSettings:ConnectionString"]!, "Redis Health", HealthStatus.Degraded);
        // controllers
        builder.Services.AddControllers();
        
        return builder;
    } 
}