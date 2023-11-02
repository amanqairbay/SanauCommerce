using Basket.API.Extensions;

WebApplication.CreateBuilder(args)
    .ConfigureServices()
    .Build()
    .ConfigureMiddlewares()
    .Run();

// Location: Basket.API