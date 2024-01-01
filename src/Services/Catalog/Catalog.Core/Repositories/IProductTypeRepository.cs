using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

/// <summary>
/// Represents a type repository.
/// </summary>
public interface IProductTypeRepository
{
    /// <summary>
    /// Gets all types.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the types.
    /// </returns>
    Task<IEnumerable<ProductType>> GetAllAsync();
}