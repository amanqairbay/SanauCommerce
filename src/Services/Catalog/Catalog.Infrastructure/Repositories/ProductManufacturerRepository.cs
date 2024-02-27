
using Catalog.Application.Contracts.Persistence;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductManufacturerRepository : IProductManufacturerRepository
{
    private readonly ICatalogContext _context;

    public ProductManufacturerRepository(ICatalogContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Gets all manufacturers.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the manufacturers.
    /// </returns>
    public async Task<IEnumerable<ProductManufacturer>> GetAllAsync() =>
        await _context
            .ProductManufacturers
            .Find(pm => true)
            .ToListAsync();

    /// <summary>
    /// Gets a product manufacturer by identifier.
    /// </summary>
    /// <param name="id">Product manufacturer identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product manufacturer.
    /// </returns>
    public async Task<ProductManufacturer> GetByIdAsync(string id) =>
        await _context
            .ProductManufacturers
            .Find(pm => pm.Id == id)
            .FirstOrDefaultAsync();

    /// <summary>
    /// Gets a product manufacturer by name.
    /// </summary>
    /// <param name="name">Product manufacturer name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product manufacturer.
    /// </returns>
    public async Task<ProductManufacturer> GetByNameAsync(string name) =>
        await _context
            .ProductManufacturers
            .Find(pm => pm.Name == name)
            .FirstOrDefaultAsync();
}