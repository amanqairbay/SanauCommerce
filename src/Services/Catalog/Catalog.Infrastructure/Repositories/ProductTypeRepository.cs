using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductTypeRepository : IProductTypeRepository
{
    private readonly ICatalogContext _context;

    public ProductTypeRepository(ICatalogContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

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
}