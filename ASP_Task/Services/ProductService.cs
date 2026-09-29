using ASP_Task.Dtos;
using ASP_Task.Models;
using ASP_Task.Repositories.Base;
using ASP_Task.Services.Base;
using Microsoft.AspNetCore.Http;

namespace ASP_Task.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductDto> GetProductsImprove()
        {
            return _unitOfWork.ProductRepo.GetProductsImprove(); // بدون Cast، لأنها ترجع ProductDto أصلاً
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _unitOfWork.CategoryRepo.GetAll();
        }

        public void AddProduct(CreateProductDto productDto)
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

            _unitOfWork.ProductRepo.Add(product);
            _unitOfWork.Save();
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
    }
}