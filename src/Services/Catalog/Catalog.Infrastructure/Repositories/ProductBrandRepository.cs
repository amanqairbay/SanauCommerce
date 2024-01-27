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

    /// <summary>
    /// Gets a product brand by identifier.
    /// </summary>
    /// <param name="id">Product brand identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product brand.
    /// </returns>
    public async Task<ProductBrand> GetByIdAsync(string id) =>
        await _context
            .ProductBrands
            .Find(pb => pb.Id == id)
            .FirstOrDefaultAsync();
}