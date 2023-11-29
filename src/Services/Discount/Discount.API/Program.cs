using Discount.API.Extensions;
using Discount.API.Repositories;
using Discount.Infrastructure.Repositories;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Discount.API", Version = "v1" }); });
builder.Services.AddHealthChecks().AddNpgSql(builder.Configuration["DatabaseSettings:ConnectionString"]!);
builder.Services.AddControllers();
      
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Discount.API v1"));
}

app.UseRouting();
app.MapControllers();
app.MapHealthChecks("/health", new HealthCheckOptions() { Predicate = _ => true, ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });
app.MigrateDatabase<Program>();
app.Run();