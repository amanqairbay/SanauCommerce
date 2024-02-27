using Catalog.Domain.Entities;

namespace Catalog.Application.Contracts.Persistence;

/// <summary>
/// Represents a product type repository.
/// </summary>
public interface IProductTypeRepository
{
    /// <summary>
    /// Gets all product types.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product types.
    /// </returns>
    Task<IEnumerable<ProductType>> GetAllAsync();

    /// <summary>
    /// Gets a product type by identifier.
    /// </summary>
    /// <param name="id">Product type identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product type.
    /// </returns>
    Task<ProductType> GetByIdAsync(string id);

    /// <summary>
    /// Gets a product type by name.
    /// </summary>
    /// <param name="name">Product type name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product type.
    /// </returns>
    Task<ProductType> GetByNameAsync(string name); 
}