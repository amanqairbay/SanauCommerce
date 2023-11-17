using Ordering.API.Extensions;

WebApplication.CreateBuilder(args)
    .ConfigureServices()
    .Build()
    .ConfigureMiddlewares()
    .Run();

// Location: Ordering.API