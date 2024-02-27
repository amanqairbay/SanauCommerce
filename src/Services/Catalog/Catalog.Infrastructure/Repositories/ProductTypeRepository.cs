using Catalog.Application.Contracts.Persistence;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

/// <summary>
/// Represents a product type repository.
/// </summary>
public class ProductTypeRepository : IProductTypeRepository
{
    private readonly ICatalogContext _context;
    
    public ProductTypeRepository(ICatalogContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Gets all product types.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product types.
    /// </returns>
    public async Task<IEnumerable<ProductType>> GetAllAsync() =>
        await _context
            .ProductTypes
            .Find(pt => true)
            .ToListAsync();

    /// <summary>
    /// Gets a product type by identifier.
    /// </summary>
    /// <param name="id">Product type identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product type.
    /// </returns>
    public async Task<ProductType> GetByIdAsync(string id) =>
        await _context
            .ProductTypes
            .Find(pt => pt.Id == id)
            .FirstOrDefaultAsync();
    
    /// <summary>
    /// Gets a product type by name.
    /// </summary>
    /// <param name="name">Product type name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product type.
    /// </returns>
    public async Task<ProductType> GetByNameAsync(string name) =>
        await _context
            .ProductTypes
            .Find(pt => pt.Name == name)
            .FirstOrDefaultAsync();
}