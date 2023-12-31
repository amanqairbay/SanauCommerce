using Web.MVC.ViewModels.Pagination;

namespace Web.MVC.ViewModels.CatalogViewModels;

public class IndexViewModel
{
    public IEnumerable<Product> Products { get; set; }
    public PaginationInfo PaginationInfo { get; set; }
    public Product Product { get; set; }
    public string Category { get; set; }
}