using Microsoft.AspNetCore.Http;

namespace ASP_Task.Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageURL { get; set; }
        public string CategoryName { get; set; }
    }

    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public IFormFile? Image { get; set; }
        public int CategoryId { get; set; }
    }
}