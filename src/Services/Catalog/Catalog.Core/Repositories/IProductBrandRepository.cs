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
}