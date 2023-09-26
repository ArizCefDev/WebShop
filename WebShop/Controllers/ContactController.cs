using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
