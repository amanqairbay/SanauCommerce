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

    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
        CatalogContextSeed.SeedData(Products);
    }
}