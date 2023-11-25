using EventBus.Messages.Common;
using MassTransit;
using Microsoft.OpenApi.Models;
using Ordering.API.EventBusConsumer;
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
        // api versioning
        builder.Services.AddApiVersioning();
        // ordering.application services
        builder.Services.AddApplicationServices();
        // ordering.infrastructure services
        builder.Services.AddInfrastructureServices(builder.Configuration);

        // mass transit rabbitmq
        builder.Services.AddMassTransit(busRegistrationConfigurator => 
        {
            busRegistrationConfigurator.AddConsumer<BasketCheckoutConsumer>();
            busRegistrationConfigurator.UsingRabbitMq((busRegistrationContext, rabbitMqBusFactoryConfigurator) => 
            { 
                rabbitMqBusFactoryConfigurator.Host(builder.Configuration["EventBusSettings:HostAddress"]);
                rabbitMqBusFactoryConfigurator.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c => c.ConfigureConsumer<BasketCheckoutConsumer>(busRegistrationContext));
            });
            
        });
        builder.Services.AddScoped<BasketCheckoutConsumer>();

        // swagger
        builder.Services.AddSwaggerGen(swaggerGenOptions => swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo{ Title = "Ordering.API", Version = "v1" }));
        // ordercontext health checks
        builder.Services.AddHealthChecks().Services.AddDbContext<OrderContext>();
        // controllers
        builder.Services.AddControllers();
        
        return builder;
    }
}