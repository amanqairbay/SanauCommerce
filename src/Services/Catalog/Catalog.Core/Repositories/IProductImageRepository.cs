using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

/// <summary>
/// Represents a product image repository.
/// </summary>
public interface IProductImageRepository
{
    /// <summary>
    /// Gets an image by identifier.
    /// </summary>
    /// <param name="id">Product image identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product image.
    /// </returns>
    Task<ProductImage> GetByIdAsync(string id);

    /// <summary>
    /// Gets a product image by name.
    /// </summary>
    /// <param name="name">Product image name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product image.
    /// </returns>
    Task<ProductImage> GetByNameAsync(string name);

    /// <summary>
    /// Creates a product image.
    /// </summary>
    /// <param name="productImage">Product.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task<ProductImage> CreateAsync(ProductImage productImage);

    /// <summary>
    /// Deletes a product image.
    /// </summary>
    /// <param name="id">Product image identifier.</param>
    /// <returns> A task that represents the asynchronous operation.</returns>
    Task<bool> DeleteAsync(string id);
}