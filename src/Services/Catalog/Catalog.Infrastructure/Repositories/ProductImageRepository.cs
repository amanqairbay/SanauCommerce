using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

/// <summary>
/// Represents a product image repository.
/// </summary>
public class ProductImageRepository : IProductImageRepository
{
    private readonly ICatalogContext _context;

    public ProductImageRepository(ICatalogContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Gets an image by identifier.
    /// </summary>
    /// <param name="productId">Product identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product image.
    /// </returns>
    public async Task<ProductImage> GetByIdAsync(string id) => 
        await _context
            .ProductImages
            .Find(pi => pi.Id == id)
            .FirstOrDefaultAsync();

    /// <summary>
    /// Gets a product image by name.
    /// </summary>
    /// <param name="name">Product image name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product image.
    /// </returns>
    public async Task<ProductImage> GetByNameAsync(string name) =>
        await _context
            .ProductImages
            .Find(p => p.Name == name)
            .FirstOrDefaultAsync();

    /// <summary>
    /// Creates a product image.
    /// </summary>
    /// <param name="productImage">Product.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<ProductImage> CreateAsync(ProductImage productImage)
    {
        await _context.ProductImages.InsertOneAsync(productImage);

        return productImage;
    }

    /// <summary>
    /// Deletes a product image.
    /// </summary>
    /// <param name="id">Product image identifier.</param>
    /// <returns> A task that represents the asynchronous operation.</returns>
    public async Task<bool> DeleteAsync(string id)
    {
        FilterDefinition<ProductImage> filter = Builders<ProductImage>.Filter.Eq(field: p => p.Id, value: id);

        DeleteResult deleteResult = await _context.ProductImages.DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}