using Microsoft.OpenApi.Models;

namespace Catalog.API.Extensions;
public static class CatalogSwaggerExtensions
{
    public static void AddSwaggerConfigure(this IServiceCollection services)
    {
        services.AddSwaggerGen(setupAction => 
        {
            setupAction.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Sanau Commerce API",
                Version = "v1",
                Description = "Sanau Commerce API",
                TermsOfService = new Uri("https://sanau-commerce.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Aman Qairbay",
                    Email = "amanqairbay@gmail.com",
                    Url = new Uri("https://sanau-commerce.com/amanqairbay"),
                },
                License = new OpenApiLicense
                {
                    Name = "Sanau System API LICX",
                    Url = new Uri("https://sanau-commerce.com/license"),
                }
            });
        });
    }

    public static WebApplication UseSwaggerMiddleware(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sanau Commerce API v1"));

        return app;
    }
}