using Catalog.API.Extensions;

WebApplication.CreateBuilder(args)
    .ConfigureServices()
    .Build()
    .ConfigureMiddlewares()
    .Run();

// Location: Catalog.API