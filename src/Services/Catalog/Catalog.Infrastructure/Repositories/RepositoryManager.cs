using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;

namespace Catalog.Infrastructure.Repositories;

/// <summary>
/// Represents a repository manager.
/// </summary>
public sealed class RepositoryManager : IRepositoryManager
{
    #region fields

    private readonly ICatalogContext _catalogContext;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<IProductBrandRepository> _productBrandRepository;
    private readonly Lazy<IProductTypeRepository> _productTypeRepository;

    #endregion fields

    public RepositoryManager(ICatalogContext catalogContext)
    {
        _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_catalogContext));
        _productBrandRepository = new Lazy<IProductBrandRepository>(() => new ProductBrandRepository(_catalogContext));
        _productTypeRepository = new Lazy<IProductTypeRepository>(() => new ProductTypeRepository(_catalogContext));
    }

    /// <summary>
    /// Gets a product repositiory.
    /// </summary>
    public IProductRepository Product => _productRepository.Value;

    /// <summary>
    /// Gets a product barnd repositiory.
    /// </summary>
    public IProductBrandRepository ProductBrand => _productBrandRepository.Value;

    /// <summary>
    /// Gets a product type repositiory.
    /// </summary>
    public IProductTypeRepository ProductType => _productTypeRepository.Value;
}