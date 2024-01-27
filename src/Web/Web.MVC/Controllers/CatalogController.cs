using Microsoft.AspNetCore.Mvc;
using Web.MVC.Services;
using Web.MVC.ViewModels.CatalogViewModels;
using Web.MVC.ViewModels.Pagination;

namespace Web.MVC.Controllers;

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
    public async Task<IActionResult> Index(int? page = 1)
    {
        // var productList = await _catalogService.GetCatalog();
        // var viewModel = new IndexViewModel() { Products = productList };
        // return View(viewModel);
        
        var itemsPage = 6;
        var catalog = await _catalogService.GetPagedCatalog(page ?? 1, itemsPage);

        var vm = new IndexViewModel()
        {
            Products = catalog.Data,
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
        //var photo = await _catalogService.GetProductImageByName(name);
        var product = await _catalogService.GetCatalogBySeName(seName);

        return View(product);
    }
}