using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

/// <summary>
/// Represents a catalog context.
/// </summary>
public class CatalogContext : ICatalogContext
{
    /// <summary>
    /// Gets the products.
    /// </summary>
    public IMongoCollection<Product> Products { get; }

    /// <summary>
    /// Gets the product brands.
    /// </summary>
    public IMongoCollection<ProductBrand> ProductBrands { get; }

    /// <summary>
    /// Gets the product types.
    /// </summary>
    public IMongoCollection<ProductType> ProductTypes { get; }

    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        
        Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
        ProductBrands = database.GetCollection<ProductBrand>(configuration["DatabaseSettings:ProductBrandsCollection"]);
        ProductTypes = database.GetCollection<ProductType>(configuration["DatabaseSettings:ProductTypesCollection"]);

        CatalogContextSeed.SeedData(Products, ProductBrands, ProductTypes);
    }
}