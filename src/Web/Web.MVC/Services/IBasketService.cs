using Web.MVC.ViewModels;

namespace Web.MVC.Services;

public interface IBasketService
{
    Task<BasketModel> GetBasket(string username);
    Task<BasketModel> UpdateBasket(BasketModel basketModel);
    Task CheckoutBasket(BasketCheckoutModel basketCheckoutModel);
}