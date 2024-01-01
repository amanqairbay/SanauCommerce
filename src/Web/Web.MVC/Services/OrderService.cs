using Web.MVC.Extensions;
using Web.MVC.ViewModels;

namespace Web.MVC.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string username)
    {
        var response = await _httpClient.GetAsync($"/Order/{username}");
        
        return await response.ReadContentAs<List<OrderResponseModel>>();
    }
}