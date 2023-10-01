using Business.Abstract;
using DTO.DTOEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _productService.GetAll();
            return View(values.OrderByDescending(x=>x.ID));
        }

        [HttpGet]
        public IActionResult Add()
        {
            IEnumerable<SelectListItem> valueGt = (from category in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = category.Name,
                                                       Value = category.ID.ToString()
                                                   }).ToList();
            ViewBag.c = valueGt;


            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductDTO p)
        {
            var userid = Convert.ToInt32(HttpContext.User.FindFirst(x => x.Type == "Id")?.Value);

            IEnumerable<SelectListItem> valueGt = (from category in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = category.Name,
                                                       Value = category.ID.ToString()
                                                   }).ToList();
            ViewBag.c = valueGt;

            p.Image = "/WebTema/images/tp4.jpg";
            p.Star = "fa fa-star yellow-star";

			p.UserID = userid;
            p.CreateDate = DateTime.Now;
            _productService.Insert(p);
            return RedirectToAction("Index");
        }

    }
}
