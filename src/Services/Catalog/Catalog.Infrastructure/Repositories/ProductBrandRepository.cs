using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductBrandRepository : IProductBrandRepository
{
    private readonly ICatalogContext _context;

    public ProductBrandRepository(ICatalogContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<ProductBrand>> GetAllAsync() =>
        await _context
            .ProductBrands
            .Find(pb => true)
            .ToListAsync();
}