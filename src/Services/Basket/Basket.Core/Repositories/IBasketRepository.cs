using Basket.Core.Entities;

namespace Basket.Core.Repositories;

/// <summary>
/// Represents a basket repository.
/// </summary>
public interface IBasketRepository
{
    /// <summary>
    /// Gets a customer's basket.
    /// </summary>
    /// <param name="userName">Customer's name</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task<ShoppingCart> GetBasketAsync(string userName);

    /// <summary>
    /// Updates a customer's basket.
    /// </summary>
    /// <param name="shoppingCart">Shopping cart.</param>
    ///  <returns>A task that represents the asynchronous operation.</returns>
    Task<ShoppingCart> UpdateBasketAsync(ShoppingCart shoppingCart);

    /// <summary>
    /// Deletes a customer's basket.
    /// </summary>
    /// <param name="userName">Customer's name.</param>
    ///  <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteBasketAsync(string userName);
}