using Web.MVC.Services;

namespace Web.MVC.Extensions;

public static class RegisterServicesExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        // services
        builder.Services.AddHttpClient<IBasketService, BasketService>(httpClient => httpClient.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]));
        builder.Services.AddHttpClient<ICatalogService, CatalogService>(httpClient => httpClient.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]));
        builder.Services.AddHttpClient<IOrderService, OrderService>(httpClient => httpClient.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]));
        
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllersWithViews();

        return builder;
    }
}