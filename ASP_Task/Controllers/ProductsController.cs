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

        // 1. عرض صفحة التعديل
        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();

            // تجهيز الـ DTO أو تمرير الموديل حسب تصميمك
            var productDto = new CreateProductDto
            {
                Name = product.Name,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId
            };

            ViewBag.Categories = new SelectList(_productService.GetAllCategories(), "Id", "Name", product.CategoryId);
            return View(productDto);
        }

        // 2. استقبال بيانات التعديل
        [HttpPost]
        public IActionResult Edit(int id, CreateProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(id, productDto);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_productService.GetAllCategories(), "Id", "Name", productDto.CategoryId);
            return View(productDto);
        }

        // 3. الحذف
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}