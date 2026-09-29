using ASP_Task.Dtos;
using ASP_Task.Models;

namespace ASP_Task.Services.Base
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProductsImprove(); // تم التعديل ليتوافق مع Dto
        IEnumerable<Category> GetAllCategories();
        void AddProduct(CreateProductDto productDto);
    }
}