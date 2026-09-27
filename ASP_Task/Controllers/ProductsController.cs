using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP_Task.Dtos;
using ASP_Task.Models;
using ASP_Task.Repositories;

namespace ASP_Task.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        private string UploadImage(IFormFile image, string name)
        {
            string fileName = name + "_" + Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Products");

            Directory.CreateDirectory(folderPath);
            string filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return "/images/Products/" + fileName;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetProductsImprove();
            return View(products);
        }

        public IActionResult Create()
        {
            var allCategories = _categoryRepository.GetAll();
            ViewBag.Categories = new SelectList(allCategories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    StockQuantity = productDto.StockQuantity,
                    CategoryId = productDto.CategoryId
                };

                if (productDto.Image != null)
                {
                    product.ImageURL = UploadImage(productDto.Image, productDto.Name);
                }

                _productRepository.Add(product);
                _productRepository.Save();
                return RedirectToAction("Index");
            }

            var allCategories = _categoryRepository.GetAll();
            ViewBag.Categories = new SelectList(allCategories, "Id", "Name");
            return View(productDto);
        }
    }
}