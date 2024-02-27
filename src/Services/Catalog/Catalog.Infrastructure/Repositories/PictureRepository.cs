using Catalog.Application.Contracts.Persistence;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

/// <summary>
/// Represents a product image repository.
/// </summary>
public class PictureRepository : IPictureRepository
{
    private readonly ICatalogContext _context;

    public PictureRepository(ICatalogContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Gets a picture by identifier.
    /// </summary>
    /// <param name="id">Picture identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the picture.
    /// </returns>
    public async Task<Picture> GetByIdAsync(string id) => 
        await _context
            .Pictures
            .Find(p => p.Id == id)
            .FirstOrDefaultAsync();

    /// <summary>
    /// Gets a picture by name.
    /// </summary>
    /// <param name="name">Picture name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the picture.
    /// </returns>
    public async Task<Picture> GetByNameAsync(string name) =>
        await _context
            .Pictures
            .Find(p => p.Name == name)
            .FirstOrDefaultAsync();

    /// <summary>
    /// Creates a picture.
    /// </summary>
    /// <param name="picture">Picture.</param>
    /// <returns>The task that represents the asynchronous operation.</returns>
    public async Task<Picture> CreateAsync(Picture picture)
    {
        await _context.Pictures.InsertOneAsync(picture);

        return picture;
    }

    /// <summary>
    /// Deletes a picture.
    /// </summary>
    /// <param name="id">Picture identifier.</param>
    /// <returns>The task that represents the asynchronous operation.</returns>
    public async Task<bool> DeleteAsync(string id)
    {
        FilterDefinition<Picture> filter = Builders<Picture>.Filter.Eq(field: p => p.Id, value: id);

        DeleteResult deleteResult = await _context.Pictures.DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}