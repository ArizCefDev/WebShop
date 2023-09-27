using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var values = _productService.GetAll();
            return View(values.OrderByDescending(x=>x.ID));
        }
    }
}
