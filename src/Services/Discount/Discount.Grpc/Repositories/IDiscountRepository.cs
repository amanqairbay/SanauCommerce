using Discount.Grpc.Entities;

namespace Discount.Grpc.Repositories;

/// <summary>
/// Represents a discount repository.
/// </summary>
public interface IDiscountRepository
{
    /// <summary>
    /// Gets a discount.
    /// </summary>
    /// <param name="productName">Product name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the discount.
    /// </returns>
    Task<Coupon> GetDiscountAsync(string productName);

    /// <summary>
    /// Creates a discount.
    /// </summary>
    /// <param name="coupon">Coupon.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    Task<bool> CreateDiscountAsync(Coupon coupon);

    /// <summary>
    /// Updates a discount.
    /// </summary>
    /// <param name="coupon">Coupon.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    Task<bool> UpdateDiscountAsync(Coupon coupon);

    /// <summary>
    /// Deletes a discount.
    /// </summary>
    /// <param name="productName">Product name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    Task<bool> DeleteDiscountAsync(string productName);
}