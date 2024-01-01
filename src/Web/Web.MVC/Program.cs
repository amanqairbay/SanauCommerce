using Web.MVC.Extensions;

WebApplication.CreateBuilder(args)
    .ConfigureServices()
    .Build()
    .ConfigureMiddlewares()
    .Run();

// Location: Web.MVC