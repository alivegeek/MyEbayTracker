using Microsoft.AspNetCore.Mvc;

namespace MyEbayTracker.Controllers
{
    public class ListingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
