using Catalog.Core.Entities;
using Catalog.Core.RequestFeatures;

namespace Catalog.Core.Repositories;

/// <summary>
/// Represents a product repository.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Gets all products.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    Task<IReadOnlyList<Product>> GetAllAsync();

    /// <summary>
    /// Gets paged products.
    /// </summary>
    /// <returns>
    /// <param name="productParams">Product parameters.</param>
    /// A task that represents the asynchronous operation.
    /// The task result contains the paged products.
    /// </returns>
    Task<Pagination<Product>> GetAllPagedAsync(ProductParameters productParams);

    /// <summary>
    /// Gets a product by identifier.
    /// </summary>
    /// <param name="id">Product identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    Task<Product> GetByIdAsync(string id);

    /// <summary>
    /// Gets a product by name.
    /// </summary>
    /// <param name="name">Product name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    Task<Product> GetByNameAsync(string name);

    /// <summary>
    /// Gets the products by name.
    /// </summary>
    /// <param name="name">Product name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the list of product.
    /// </returns>
    Task<IReadOnlyList<Product>> GetAllByNameAsync(string name);

    /// <summary>
    /// Gets the product by type.
    /// </summary>
    /// <param name="typeId">Product type identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    Task<IReadOnlyList<Product>> GetByTypeAsync(string typeId);

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="product">Product.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task<Product> CreateAsync(Product product);

    /// <summary>
    /// Updates a product.
    /// </summary>
    /// <param name="product">Product.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task<bool> UpdateAsync(Product product);

    /// <summary>
    /// Deletes a product.
    /// </summary>
    /// <param name="id">Product identifier.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task<bool> DeleteAsync(string id);
}