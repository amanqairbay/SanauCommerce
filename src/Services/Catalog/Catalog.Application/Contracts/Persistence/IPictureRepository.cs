using Catalog.Domain.Entities;

namespace Catalog.Application.Contracts.Persistence;

/// <summary>
/// Represents a picture repository.
/// </summary>
public interface IPictureRepository
{
    /// <summary>
    /// Gets a picture by identifier.
    /// </summary>
    /// <param name="id">Picture identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the picture.
    /// </returns>
    Task<Picture> GetByIdAsync(string id);

    /// <summary>
    /// Gets a picture by name.
    /// </summary>
    /// <param name="name">Picture name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the picture.
    /// </returns>
    Task<Picture> GetByNameAsync(string name);

    /// <summary>
    /// Creates a picture.
    /// </summary>
    /// <param name="picture">Picture.</param>
    /// <returns>The task that represents the asynchronous operation.</returns>
    Task<Picture> CreateAsync(Picture picture);

    /// <summary>
    /// Deletes a picture.
    /// </summary>
    /// <param name="id">Picture identifier.</param>
    /// <returns>The task that represents the asynchronous operation.</returns>
    Task<bool> DeleteAsync(string id);
}