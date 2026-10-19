using ASP_Task.Infrastructure.Data;
using ASP_Task.Application.Dtos;
using ASP_Task.Domain.Models;

namespace ASP_Task.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext db) : base(db)
        {
        }

        public IEnumerable<OrderDto> GetOrdersImprove()
        {
            return _db.Orders
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    CustomerName = o.Customer.Name
                })
                .ToList();
        }
    }
}