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
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Gets all products.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    public async Task<IReadOnlyList<Product>> GetAllAsync() =>
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
    public async Task<Pagination<Product>> GetAllPagedAsync(ProductParameters productParams)
    {
        var builder = Builders<Product>.Filter;
        var filter = builder.Empty;

        filter &= builder.Where(p => p.Price >= productParams.MinPrice && p.Price <= productParams.MaxPrice);

        if (!string.IsNullOrEmpty(productParams.SearchTerm))
        {
            var searchTerm = productParams.SearchTerm.Trim().ToLower();

            filter &= builder.Where(p => p.Name.ToLower() == searchTerm || p.Name.ToLower().Contains(searchTerm));
                
            //filter &= builder.Regex(p => p.Name, new BsonRegularExpression(productParams.SearchTerm));
        }

        if (productParams.BrandId != null)
        {
            //filter &= builder.Eq(p => p.Brand.Id, productParams.BrandId);
            foreach (var brandId in productParams.BrandId)
            {
                filter &= builder.Where(p => productParams.BrandId.Contains(p.Brand.Id));
            }
        }

        if (!string.IsNullOrEmpty(productParams.TypeId))
            filter &= builder.Eq(p => p.Type.Id, productParams.TypeId);

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
    public async Task<Product> GetByIdAsync(string id) =>
        await _context
            .Products
            .Find(p => p.Id == id)
            .FirstOrDefaultAsync();

    /// <summary>
    /// Gets a product by name.
    /// </summary>
    /// <param name="id">Product name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    public async Task<Product> GetByNameAsync(string name) =>
        await _context
            .Products
            .Find(p => p.Name == name)
            .FirstOrDefaultAsync();
    

    /// <summary>
    /// Gets the products by name.
    /// </summary>
    /// <param name="name">Product name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the list of product.
    /// </returns>
    public async Task<IReadOnlyList<Product>> GetAllByNameAsync(string name)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);
        
        return await _context
                .Products
                .Find(filter)
                .ToListAsync();
    }

    /// <summary>
    /// Gets the product by type.
    /// </summary>
    /// <param name="typeName">Product type name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    public async Task<IReadOnlyList<Product>> GetByTypeAsync(string typeName)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Type.Name, typeName);
        
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
    public async Task<Product> CreateAsync(Product product) 
    {

        await _context.Products.InsertOneAsync(product);

        return product;
    }

    /// <summary>
    /// Updates a product.
    /// </summary>
    /// <param name="product">Product.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<bool> UpdateAsync(Product product)
    {
        var updateResult = await _context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    /// <summary>
    /// Deletes a product.
    /// </summary>
    /// <param name="id">Product identifier.</param>
    /// <returns> A task that represents the asynchronous operation.</returns>
    public async Task<bool> DeleteAsync(string id)
    {
        FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(field: p => p.Id, value: id);

        DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}