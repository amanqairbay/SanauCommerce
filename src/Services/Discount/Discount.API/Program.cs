using Discount.API.Extensions;

WebApplication.CreateBuilder(args)
    .ConfigureServices()
    .Build()
    .ConfigureMiddlewares()
    .Run();

// Location: Discount.API