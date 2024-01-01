namespace Catalog.Core.Repositories;

/// <summary>
/// Represents a repository manager.
/// </summary>
public interface IRepositoryManager
{
    /// <summary>
    /// Gets a product repositiory.
    /// </summary>
    IProductRepository Product { get; }

    /// <summary>
    /// Gets a product barnd repositiory.
    /// </summary>
    IProductBrandRepository ProductBrand { get; }

    /// <summary>
    /// Gets a product type repositiory.
    /// </summary>
    IProductTypeRepository ProductType { get; }
}