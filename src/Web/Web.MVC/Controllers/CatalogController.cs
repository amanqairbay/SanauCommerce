using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.MVC.Services;
using Web.MVC.ViewModels;
using Web.MVC.ViewModels.CatalogViewModels;
using Web.MVC.ViewModels.Pagination;

namespace Web.MVC.Controllers;

[Authorize]
public class CatalogController : Controller
{
    private readonly ICatalogService _catalogService;
    private readonly ILogger<CatalogController> _logger;

    public CatalogController(ICatalogService catalogService, ILogger<CatalogController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
    }

    [HttpGet, Route("catalog")]
    public async Task<IActionResult> Index(int? page = 1, string category = null, List<string> brand = null)
    {
        // var productList = await _catalogService.GetCatalog();
        // var viewModel = new IndexViewModel() { Products = productList };
        // return View(viewModel);
        
        var itemsPage = 6;
        var catalog = await _catalogService.GetPagedCatalog(page ?? 1, itemsPage, category, brand);
        List<ProductType> typeList = new();
        List<ProductBrand> brandList = new();

        List<ProductBrand> brands = await _catalogService.GetProductBrands();

        if (category is null)
        {
            typeList = await _catalogService.GetProductTypes();
        }
        else
        {
            var type = await _catalogService.GetProductType(category);
            typeList.Add(type);

            brands = new();
            
            foreach(var item in catalog.Data)
            {
                brands.Add(item.Brand);
            }
        }

        if (brand is null)
        {
            brandList = await _catalogService.GetProductBrands();
        }
        else
        {
            foreach (var item in brand)
            {
                var brandFromDb = await _catalogService.GetProductBrand(item);
                brandList.Add(brandFromDb);
            }
        }

        var vm = new IndexViewModel()
        {
            Products = catalog.Data,
            ProductTypes = typeList,
            ProductBrands = brands.Distinct().ToList(),
            PaginationInfo = new PaginationInfo
            {
               ActualPage = page ?? 1,
               ItemsPerPage = catalog.Data.Count,
               TotalItems = catalog.Count,
               TotalPages = (int)Math.Ceiling(((decimal)catalog.Count / itemsPage))
            }
        };

        vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 0) ? "disabled" : "";
        vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 1) ? "disabled" : "";

        return View(vm);
    }
    
    [HttpGet("catalog/p/{seName}", Name = "ProductDetails")]
    public async Task<IActionResult> ProductDetails(string seName)
    {
        var product = await _catalogService.GetCatalogBySeName(seName);

        return View(product);
    }

    
    [HttpPost]
    public async Task<IActionResult> GetProducts(List<string> brand = null)
    {
        var itemsPage = 6;
        var catalog = await _catalogService.GetPagedCatalog(1, itemsPage, null, brand);

        var vm = new IndexViewModel
        {
            Products = catalog.Data,
            ProductBrands = await _catalogService.GetProductBrands(),
            ProductTypes = await _catalogService.GetProductTypes(),
            PaginationInfo = new PaginationInfo
            {
               ActualPage = 1,
               ItemsPerPage = catalog.Data.Count,
               TotalItems = catalog.Count,
               TotalPages = (int)Math.Ceiling(((decimal)catalog.Count / itemsPage))
            }
        };

        vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 0) ? "disabled" : "";
        vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 1) ? "disabled" : "";

        return RedirectToAction("Index", "Catalog", new { page = 1, category = "", brand = brand});
        //return PartialView("_Products", catalog.Data);
        //return View("Index", vm);
    }
}