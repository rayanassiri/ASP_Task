using ASP_Task.Infrastructure.Data;
using ASP_Task.Application.Dtos;
using ASP_Task.Domain.Models;

namespace ASP_Task.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext db) : base(db)
        {
        }

        public IEnumerable<ProductDto> GetProductsImprove()
        {
            return _db.Products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    ImageURL = p.ImageURL,
                    CategoryName = p.Category.Name
                })
                .ToList();
        }
    }
}