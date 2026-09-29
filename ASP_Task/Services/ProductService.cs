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
            return _unitOfWork.ProductRepo.GetProductsImprove();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _unitOfWork.CategoryRepo.GetAll();
        }

 
        public Product GetProductById(int id)
        {
            return _unitOfWork.ProductRepo.GetById(id);
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

        public void UpdateProduct(int id, CreateProductDto productDto)
        {
            var product = _unitOfWork.ProductRepo.GetById(id);
            if (product != null)
            {
                product.Name = productDto.Name;
                product.Price = productDto.Price;
                product.StockQuantity = productDto.StockQuantity;
                product.CategoryId = productDto.CategoryId;

                if (productDto.Image != null)
                {
                    product.ImageURL = UploadImage(productDto.Image, productDto.Name);
                }

                _unitOfWork.ProductRepo.Update(product);
                _unitOfWork.Save();
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _unitOfWork.ProductRepo.GetById(id);
            if (product != null)
            {
                _unitOfWork.ProductRepo.Delete(id); 
                _unitOfWork.Save();
            }
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