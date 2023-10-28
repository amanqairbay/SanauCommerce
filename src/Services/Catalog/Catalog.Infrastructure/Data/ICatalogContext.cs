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
}