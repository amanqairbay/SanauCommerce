using Web.MVC.ViewModels;

namespace Web.MVC.Services;
public interface IOrderService
{
    Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string username);
}