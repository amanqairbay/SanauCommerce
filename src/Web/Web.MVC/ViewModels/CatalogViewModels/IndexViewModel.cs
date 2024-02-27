using Web.MVC.ViewModels.Pagination;

namespace Web.MVC.ViewModels.CatalogViewModels;

public class IndexViewModel
{
    public IEnumerable<Product> Products { get; set; }
    public List<ProductType> ProductTypes { get; set; }
    public List<ProductBrand> ProductBrands { get; set; }
    public PaginationInfo PaginationInfo { get; set; }
}