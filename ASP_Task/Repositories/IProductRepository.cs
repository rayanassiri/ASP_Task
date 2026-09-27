using ASP_Task.Dtos;
using ASP_Task.Models;

namespace ASP_Task.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<ProductDto> GetProductsImprove();
    }
}