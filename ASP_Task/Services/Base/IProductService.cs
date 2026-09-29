using ASP_Task.Dtos;
using ASP_Task.Models;

namespace ASP_Task.Services.Base
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