
using Catalog.Domain.Entities;
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
    /// Gets the product manufacturers.
    /// </summary>
    public IMongoCollection<ProductManufacturer> ProductManufacturers { get; }

    /// <summary>
    /// Gets the products.
    /// </summary>
    public IMongoCollection<ProductType> ProductTypes { get; }

    /// <summary>
    /// Gets the product categories.
    /// </summary>
    public IMongoCollection<Category> Categories { get; }

    /// <summary>
    /// Gets the product pictures.
    /// </summary>
    public IMongoCollection<Picture> Pictures { get; }

    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        
        Products = database.GetCollection<Product>(configuration["DatabaseSettings:ProductCollection"]);
        ProductManufacturers = database.GetCollection<ProductManufacturer>(configuration["DatabaseSettings:ProductManufacturerCollection"]);
        ProductTypes = database.GetCollection<ProductType>(configuration["DatabaseSettings:ProductTypeCollection"]);
        Categories = database.GetCollection<Category>(configuration["DatabaseSettings:CategoryCollection"]);
        Pictures = database.GetCollection<Picture>(configuration["DatabaseSettings:PictureCollection"]);

        CatalogContextSeed.SeedData(Products, ProductManufacturers, ProductTypes, Categories, Pictures);
    }
}