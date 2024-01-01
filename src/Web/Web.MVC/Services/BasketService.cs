using Web.MVC.Extensions;
using Web.MVC.ViewModels;

namespace Web.MVC.Services;
public class BasketService : IBasketService
{
    private readonly HttpClient _httpClient;

    public BasketService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<BasketModel> GetBasket(string username)
    {
        var response = await _httpClient.GetAsync($"/Basket/{username}");

        return await response.ReadContentAs<BasketModel>();
    }

    public async Task<BasketModel> UpdateBasket(BasketModel basketModel)
    {
        var response = await _httpClient.PostAsJson($"/Basket", basketModel);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<BasketModel>();
        else
        {
            throw new Exception("Something went wrong when calling api.");
        }
    }

    public async Task CheckoutBasket(BasketCheckoutModel basketCheckoutModel)
    {
        var response = await _httpClient.PostAsJson($"/Basket/Checkout", basketCheckoutModel);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Something went wrong when calling api.");
    }
}