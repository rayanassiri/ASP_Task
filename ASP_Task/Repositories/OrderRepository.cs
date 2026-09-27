using ASP_Task.Data;
using ASP_Task.Dtos;
using ASP_Task.Models;

namespace ASP_Task.Repositories
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