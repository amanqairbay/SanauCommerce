
using Catalog.Application.Contracts.Persistence;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ICatalogContext _context;

    public CategoryRepository(ICatalogContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Gets all product categories.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product categories.
    /// </returns>
    public async Task<IEnumerable<Category>> GetAllAsync() =>
        await _context
            .Categories
            .Find(c => true)
            .ToListAsync();

    /// <summary>
    /// Gets a product category by identifier.
    /// </summary>
    /// <param name="id">Product category identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product category.
    /// </returns>
    public async Task<Category> GetByIdAsync(string id) =>
        await _context
            .Categories
            .Find(c => c.Id == id)
            .FirstOrDefaultAsync();
    
    /// <summary>
    /// Gets a product category by name.
    /// </summary>
    /// <param name="name">Product category name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product category.
    /// </returns>
    public async Task<Category> GetByNameAsync(string name) =>
        await _context
            .Categories
            .Find(c => c.Name == name)
            .FirstOrDefaultAsync();
}