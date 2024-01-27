using Web.MVC.ViewModels.Pagination;

namespace Web.MVC.ViewModels.CatalogViewModels;

public class IndexViewModel
{
    public IEnumerable<Product> Products { get; set; }
    public IEnumerable<ProductType> ProductTypes { get; set; }
    public PaginationInfo PaginationInfo { get; set; }
}