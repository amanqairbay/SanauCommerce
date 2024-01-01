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
}