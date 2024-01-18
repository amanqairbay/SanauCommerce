using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

/// <summary>
/// Represents a catalog context.
/// </summary>
public interface ICatalogContext
{
    /// <summary>
    /// Gets the products.
    /// </summary>
    IMongoCollection<Product> Products { get; }

    /// <summary>
    /// Gets the product brands.
    /// </summary>
    IMongoCollection<ProductBrand> ProductBrands { get; }

    /// <summary>
    /// Gets the product types.
    /// </summary>
    IMongoCollection<ProductType> ProductTypes { get; }

    /// <summary>
    /// Gets the product images.
    /// </summary>
    IMongoCollection<ProductImage> ProductImages { get; }
}