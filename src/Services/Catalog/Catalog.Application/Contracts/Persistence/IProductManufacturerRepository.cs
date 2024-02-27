using Catalog.Domain.Entities;

namespace Catalog.Application.Contracts.Persistence;

/// <summary>
/// represents a product's manufacturer repository.
/// </summary>
public interface IProductManufacturerRepository
{
    /// <summary>
    /// Gets all manufacturer.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the manufacturers.
    /// </returns>
    Task<IEnumerable<ProductManufacturer>> GetAllAsync();

    /// <summary>
    /// Gets a manufacturer by identifier.
    /// </summary>
    /// <param name="id">Manufacturer identifier.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the manufacturer.
    /// </returns>
    Task<ProductManufacturer> GetByIdAsync(string id);

    /// <summary>
    /// Gets a manufacturer by name.
    /// </summary>
    /// <param name="name">Manufacturer name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the manufacturer.
    /// </returns>
    Task<ProductManufacturer> GetByNameAsync(string name);
}