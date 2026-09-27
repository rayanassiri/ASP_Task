using ASP_Task.Dtos;
using ASP_Task.Models;

namespace ASP_Task.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<OrderDto> GetOrdersImprove();
    }
}