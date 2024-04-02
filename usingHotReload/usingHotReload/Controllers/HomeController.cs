using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using usingHotReload.Models;

namespace usingHotReload.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public IActionResult Index()
        {
            ViewBag.Name = "Türkay";
            ViewBag.LastName = "Yaldız";
            ViewBag.Hede = "Deneme";
            return View(productService.GetProductNames());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
