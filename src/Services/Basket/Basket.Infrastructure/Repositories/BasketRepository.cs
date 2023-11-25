using Basket.Core.Entities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Infrastructure.Repositories;

/// <summary>
/// Represents a basket repository.
/// </summary>
public class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _redisCache;

    public BasketRepository(IDistributedCache redisCache)
    {
        _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
    }

    /// <summary>
    /// Gets a customer's basket.
    /// </summary>
    /// <param name="userName">Customer's name</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<ShoppingCart> GetBasketAsync(string userName)
    {
        var basket = await _redisCache.GetStringAsync(userName);

        if (string.IsNullOrEmpty(basket))
            return null!;

        return JsonConvert.DeserializeObject<ShoppingCart>(basket)!;
    }

    /// <summary>
    /// Updates a customer's basket.
    /// </summary>
    /// <param name="shoppingCart">Shopping cart.</param>
    ///  <returns>A task that represents the asynchronous operation.</returns>
    public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart shoppingCart)
    {
        await _redisCache.SetStringAsync(shoppingCart.UserName, JsonConvert.SerializeObject(shoppingCart));

        return await GetBasketAsync(shoppingCart.UserName);
    }

    /// <summary>
    /// Deletes a customer's basket.
    /// </summary>
    /// <param name="userName">Customer's name.</param>
    ///  <returns>A task that represents the asynchronous operation.</returns>
    public async Task DeleteBasketAsync(string userName)
    {
        await _redisCache.RemoveAsync(userName);
    }
}