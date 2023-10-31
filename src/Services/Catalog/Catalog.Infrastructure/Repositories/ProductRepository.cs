using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.RequestFeatures;
using Catalog.Infrastructure.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

/// <summary>
/// Represents a product repository.
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly ICatalogContext _context;

    public ProductRepository(ICatalogContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets all products.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    public async Task<IReadOnlyList<Product>> GetProductsAsync() =>
        await _context
            .Products
            .Find(p => true)
            .ToListAsync();

    /// <summary>
    /// Gets paged products.
    /// </summary>
    /// <returns>
    /// <param name="productParams">Product parameters.</param>
    /// A task that represents the asynchronous operation.
    /// The task result contains the paged products.
    /// </returns>
    public async Task<Pagination<Product>> GetPagedProductsAsync(ProductParameters productParams)
    {
        var builder = Builders<Product>.Filter;
        var filter = builder.Empty;

        if (!string.IsNullOrEmpty(productParams.SearchTerm))
            filter &= builder.Regex(p => p.Name, new BsonRegularExpression(productParams.SearchTerm));

        if (!string.IsNullOrEmpty(productParams.Sort))
        {
            return new Pagination<Product>()
            {
                PageSize = productParams.PageSize,
                PageIndex = productParams.PageIndex,
                Data = await DataFilter(productParams, filter),
                Count = await _context.Products.CountDocumentsAsync(p => true) //TODO: Need to check while applying with UI
            };
        }

        return new Pagination<Product>()
        {
            PageSize = productParams.PageSize,
            PageIndex = productParams.PageIndex,
            Data = await _context.Products
                    .Find(filter)
                    .Sort(Builders<Product>.Sort.Ascending("Name"))
                    .Skip(productParams.PageSize * (productParams.PageIndex - 1))
                    .Limit(productParams.PageSize)
                    .ToListAsync(),
            Count = await _context.Products.CountDocumentsAsync(p => true)
        };
    }

    private async Task<IReadOnlyList<Product>> DataFilter(ProductParameters productParams, FilterDefinition<Product> filter)
    {
        return productParams.Sort switch
        {
            "priceAsc" => await _context.Products
                           .Find(filter)
                           .Sort(Builders<Product>.Sort.Ascending("Price"))
                           .Skip(productParams.PageSize * (productParams.PageIndex - 1))
                           .Limit(productParams.PageSize)
                           .ToListAsync(),

            "priceDesc" => await _context.Products
                            .Find(filter)
                            .Sort(Builders<Product>.Sort.Descending("Price"))
                            .Skip(productParams.PageSize * (productParams.PageIndex - 1))
                            .Limit(productParams.PageSize)
                            .ToListAsync(),

            _ => await _context.Products
                  .Find(filter)
                  .Sort(Builders<Product>.Sort.Ascending("Name"))
                  .Skip(productParams.PageSize * (productParams.PageIndex - 1))
                  .Limit(productParams.PageSize)
                  .ToListAsync(),
        };
    }

    /// <summary>
    /// Gets a product by identifier.
    /// </summary>
    /// <param name="id">Product identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    public async Task<Product> GetProductByIdAsync(string id) =>
        await _context
            .Products
            .Find(p => p.Id == id)
            .FirstOrDefaultAsync();
    

    /// <summary>
    /// Gets the product by name.
    /// </summary>
    /// <param name="name">Product name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    public async Task<IReadOnlyList<Product>> GetProductByNameAsync(string name)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);
        
        return await _context
                .Products
                .Find(filter)
                .ToListAsync();
    }

    /// <summary>
    /// Gets the product by category.
    /// </summary>
    /// <param name="categoryName">Category name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    public async Task<IReadOnlyList<Product>> GetProductByCategoryAsync(string categoryName)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
        
        return await _context
                .Products
                .Find(filter)
                .ToListAsync();
    }

    /// <summary>
    /// Creates a product.
    /// </summary>
    /// <param name="product">Product.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<Product> CreateProductAsync(Product product) 
    {
        await _context.Products.InsertOneAsync(product);

        return product;
    }

    /// <summary>
    /// Updates a product.
    /// </summary>
    /// <param name="product">Product.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<bool> UpdateProductAsync(Product product)
    {
        var updateResult = await _context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    /// <summary>
    /// Deletes a product.
    /// </summary>
    /// <param name="id">Product identifier.</param>
    /// <returns> A task that represents the asynchronous operation.</returns>
    public async Task<bool> DeleteProductAsync(string id)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

        DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}