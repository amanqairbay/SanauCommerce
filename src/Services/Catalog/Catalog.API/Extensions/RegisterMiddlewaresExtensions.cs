using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Catalog.API.Extensions;

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
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
        }

        app.UseRouting();
        app.MapControllers();
        app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true, ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });

        return app;
    }
}