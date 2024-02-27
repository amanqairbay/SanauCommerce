using Web.MVC.ViewModels;

namespace Web.MVC.Services;

public interface ICatalogService
{
    Task<IEnumerable<Product>> GetCatalog();
    Task<Catalog> GetPagedCatalog(int page, int take, string typeId, List<string> brands);
    Task<IEnumerable<Product>> GetCatalogByCategory(string category);
    Task<Product> GetCatalogByName(string name);
    Task<Product> GetCatalogBySeName(string seName);
    Task<ProductImage> GetProductImageByName(string name);
    Task<Product> GetCatalog(string id);
    Task<Product> CreateCatalog(Product product);

    Task<List<ProductType>> GetProductTypes();
    Task<ProductType> GetProductType(string id);

    Task<List<ProductBrand>> GetProductBrands();
    Task<ProductBrand> GetProductBrand(string id);
}