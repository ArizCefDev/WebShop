using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
