using Discount.Infrastructure.Extensions;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Discount.API.Extensions;

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
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Discount.API v1"));
        }

        app.UseRouting();

        #pragma warning disable ASP0014 // Suggest using top level route registrations
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        });
        #pragma warning restore ASP0014 // Suggest using top level route registrations

        app.MigrateDatabase<Program>();
        
        return app;
    }
}