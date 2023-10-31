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
    Task<IReadOnlyList<Product>> GetProductsAsync();

    /// <summary>
    /// Gets paged products.
    /// </summary>
    /// <returns>
    /// <param name="productParams">Product parameters.</param>
    /// A task that represents the asynchronous operation.
    /// The task result contains the paged products.
    /// </returns>
    Task<Pagination<Product>> GetPagedProductsAsync(ProductParameters productParams);

    /// <summary>
    /// Gets a product by identifier.
    /// </summary>
    /// <param name="id">Product identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    Task<Product> GetProductByIdAsync(string id);

    /// <summary>
    /// Gets the product by name.
    /// </summary>
    /// <param name="name">Product name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    Task<IReadOnlyList<Product>> GetProductByNameAsync(string name);

    /// <summary>
    /// Gets the product by category.
    /// </summary>
    /// <param name="categoryName">Category name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    Task<IReadOnlyList<Product>> GetProductByCategoryAsync(string categoryName);

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="product">Product.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task<Product> CreateProductAsync(Product product);

    /// <summary>
    /// Updates a product.
    /// </summary>
    /// <param name="product">Product.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task<bool> UpdateProductAsync(Product product);

    /// <summary>
    /// Deletes a product.
    /// </summary>
    /// <param name="id">Product identifier.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task<bool> DeleteProductAsync(string id);
}