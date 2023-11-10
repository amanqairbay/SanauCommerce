using Discount.Grpc.Repositories;
using Discount.Infrastructure.Repositories;
using Discount.Grpc.Services;
using Discount.Grpc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddGrpc();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

#pragma warning disable ASP0014 // Suggest using top level route registrations

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<DiscountService>();
    endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client."); });
});

#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run();
