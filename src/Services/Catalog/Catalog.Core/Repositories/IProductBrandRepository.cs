using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

/// <summary>
/// Represents a brand repository.
/// </summary>
public interface IProductBrandRepository
{
    /// <summary>
    /// Gets all brands.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brands.
    /// </returns>
    Task<IEnumerable<ProductBrand>> GetAllAsync();

    /// <summary>
    /// Gets a product brand by identifier.
    /// </summary>
    /// <param name="id">Product brand identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product brand.
    /// </returns>
    Task<ProductBrand> GetByIdAsync(string id);
}