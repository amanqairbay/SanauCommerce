using Catalog.Domain.Entities;

namespace Catalog.Application.Contracts.Persistence;

/// <summary>
/// Represents a product category repository.
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Gets all product categories.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product categories.
    /// </returns>
    Task<IEnumerable<Category>> GetAllAsync();

    /// <summary>
    /// Gets a product category by identifier.
    /// </summary>
    /// <param name="id">Product category identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product category.
    /// </returns>
    Task<Category> GetByIdAsync(string id);

    /// <summary>
    /// Gets a product category by name.
    /// </summary>
    /// <param name="name">Product category name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product category.
    /// </returns>
    Task<Category> GetByNameAsync(string name);
}