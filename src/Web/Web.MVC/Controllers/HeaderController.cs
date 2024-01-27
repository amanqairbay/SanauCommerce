using Microsoft.AspNetCore.Mvc;

namespace Web.MVC.Controllers;
public class HeaderController : Controller
{
    List<string> Categories = new() { "Home", "Smartphones", "Tablets", "Laptops", "Laptops", "Headphones", "Smartwatches", "Audio & TV" };
    
    public ActionResult Menu()
    {
        return PartialView("_Header");
    }
}