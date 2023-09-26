using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
