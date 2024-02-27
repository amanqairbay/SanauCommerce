
using Catalog.Domain.Entities;
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
    /// Gets the product manufacturers.
    /// </summary>
    IMongoCollection<ProductManufacturer> ProductManufacturers { get; }

    /// <summary>
    /// Gets the products.
    /// </summary>
    IMongoCollection<ProductType> ProductTypes { get; }

    /// <summary>
    /// Gets the product categories.
    /// </summary>
    IMongoCollection<Category> Categories { get; }

    /// <summary>
    /// Gets the product pictures.
    /// </summary>
    IMongoCollection<Picture> Pictures { get; }
}