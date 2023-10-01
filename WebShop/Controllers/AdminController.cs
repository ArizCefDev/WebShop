using Business.Abstract;
using DTO.DTOEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public AdminController(IProductService productService, ICategoryService categoryService, IUserService userService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Product List
        public IActionResult ProductIndex()
        {
            var values = _productService.GetAllWithInclude();
            return View(values.OrderByDescending(x=>x.ID));
        }

        //Product Add
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

            p.UserID = userid;
            p.CreateDate= DateTime.Now;
            _productService.Insert(p);
            return RedirectToAction("ProductIndex");
        }

        //Product Update

        [HttpGet]
        public IActionResult Update(int id)
        {
            IEnumerable<SelectListItem> valueGt = (from category in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = category.Name,
                                                       Value = category.ID.ToString()
                                                   }).ToList();
            ViewBag.c = valueGt;

            var values = _productService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult Update(ProductDTO p)
        {
            IEnumerable<SelectListItem> valueGt = (from category in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = category.Name,
                                                       Value = category.ID.ToString()
                                                   }).ToList();
            ViewBag.c = valueGt;

           
            _productService.Update(p);
            return RedirectToAction("ProductIndex");
        }

        //Product Delete
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("ProductIndex");
        }
    }
}
