using ASP_Task.Application.Dtos;
using ASP_Task.Domain.Models;

namespace ASP_Task.Application.Services.Base
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProductsImprove();
        IEnumerable<Category> GetAllCategories();
        Product GetProductById(int id);
        void AddProduct(CreateProductDto productDto);
        void UpdateProduct(int id, CreateProductDto productDto);
        void DeleteProduct(int id);
    }
}