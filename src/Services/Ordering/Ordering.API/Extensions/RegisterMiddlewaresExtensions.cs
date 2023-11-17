using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Ordering.Infrastructure.Persistence;

#nullable disable

namespace Ordering.API.Extensions;

/// <summary>
/// Represents a registry of middlewares.
/// </summary>
public static class RegisterMiddlewaresExtensions
{
    /// <summary>
    /// Configures middlewares.
    /// </summary>
    /// <param name="app">The web application used to configure the HTTP pipeline, and routes.</param>
    /// <returns>
    /// Returns a configured WebApplication.
    /// </returns>
    public static WebApplication ConfigureMiddlewares(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ordering.API v1"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();

    #pragma warning disable ASP0014 // Suggest using top level route registrations

        app.UseEndpoints(cfg =>
        {
            cfg.MapControllers();
            cfg.MapHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        });
    
    #pragma warning restore ASP0014 // Suggest using top level route registrations

        app.MigrateDatabase<OrderContext>((context, services) =>
        {
            var logger = services.GetService<ILogger<OrderContextSeed>>();
            
            OrderContextSeed.SeedAsync(context, logger).Wait();
        });

        return app;
    }
}