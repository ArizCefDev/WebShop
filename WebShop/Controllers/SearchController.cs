using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
	public class SearchController : Controller
	{
		private readonly IProductService _productService;

		public SearchController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index(string product)
		{
			var values = from p in _productService.GetAll() select p;
			if (!string.IsNullOrEmpty(product))
			{
				values = values.Where(x => x.Title.ToLower().Contains(product.ToLower())); ;
			}
			return View(values.OrderByDescending(x => x.ID));
		}
	}
}
