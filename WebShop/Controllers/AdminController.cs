using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Product
        public IActionResult ProductIndex()
        {
            var values = _productService.GetAll();
            return View(values.OrderByDescending(x=>x.ID));
        }
    }
}
