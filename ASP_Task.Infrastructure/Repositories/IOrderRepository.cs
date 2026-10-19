using ASP_Task.Application.Dtos;
using ASP_Task.Domain.Models;

namespace ASP_Task.Infrastructure.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<OrderDto> GetOrdersImprove();
    }
}