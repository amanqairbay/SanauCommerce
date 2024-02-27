namespace Catalog.Application.Contracts.Persistence;

/// <summary>
/// Represents a manager repository.
/// </summary>
public interface IRepositoryManager
{
    /// <summary>
    /// Gets a category repositiory.
    /// </summary>
    ICategoryRepository Category { get; }

    /// <summary>
    /// Gets a picture repositiory.
    /// </summary>
    IPictureRepository Picture { get; }

    /// <summary>
    /// Gets a product repositiory.
    /// </summary>
    IProductRepository Product { get; }

    /// <summary>
    /// Gets a product manufacturer repositiory.
    /// </summary>
    IProductManufacturerRepository ProductManufacturer { get; }

    /// <summary>
    /// Gets a product type repositiory.
    /// </summary>
    IProductTypeRepository ProductType { get; }
}