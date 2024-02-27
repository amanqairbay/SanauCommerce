
using Catalog.Application.Contracts.Persistence;
using Catalog.Infrastructure.Data;

namespace Catalog.Infrastructure.Repositories;

/// <summary>
/// Represents a repository manager.
/// </summary>
public sealed class RepositoryManager : IRepositoryManager
{
    #region fields

    private readonly ICatalogContext _catalogContext;
    private readonly Lazy<ICategoryRepository> _categoryRepository;
    private readonly Lazy<IPictureRepository> _pictureRepository;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<IProductManufacturerRepository> _productManufacturerRepository;
    private readonly Lazy<IProductTypeRepository> _productTypeRepository;
    

    #endregion fields

    public RepositoryManager(ICatalogContext catalogContext)
    {
        _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_catalogContext));
        _pictureRepository = new Lazy<IPictureRepository>(() => new PictureRepository(_catalogContext));
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_catalogContext));
        _productManufacturerRepository = new Lazy<IProductManufacturerRepository>(() => new ProductManufacturerRepository(_catalogContext));
        _productTypeRepository = new Lazy<IProductTypeRepository>(() => new ProductTypeRepository(_catalogContext));
    }

    /// <summary>
    /// Gets a category repositiory.
    /// </summary>
    public ICategoryRepository Category => _categoryRepository.Value;

    /// <summary>
    /// Gets a picture repositiory.
    /// </summary>
    public IPictureRepository Picture => _pictureRepository.Value;

    /// <summary>
    /// Gets a product repositiory.
    /// </summary>
    public IProductRepository Product => _productRepository.Value;

    /// <summary>
    /// Gets a product manufacturer repositiory.
    /// </summary>
    public IProductManufacturerRepository ProductManufacturer => _productManufacturerRepository.Value;

    /// <summary>
    /// Gets a product type repositiory.
    /// </summary>
    public IProductTypeRepository ProductType => _productTypeRepository.Value;
}