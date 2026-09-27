using ASP_Task.Data;
using ASP_Task.Dtos;
using ASP_Task.Models;

namespace ASP_Task.Repositories
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