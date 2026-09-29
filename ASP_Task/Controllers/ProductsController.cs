using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP_Task.Dtos;
using ASP_Task.Services.Base;

namespace ASP_Task.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetProductsImprove();
            return View(products);
        }

        public IActionResult Create()
        {
            var allCategories = _productService.GetAllCategories();
            ViewBag.Categories = new SelectList(allCategories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(productDto);
                return RedirectToAction("Index");
            }

            var allCategories = _productService.GetAllCategories();
            ViewBag.Categories = new SelectList(allCategories, "Id", "Name");
            return View(productDto);
        }
    }
}