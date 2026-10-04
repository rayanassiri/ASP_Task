using ASP_Task.Application.Dtos;
using ASP_Task.Domain.Models;

namespace ASP_Task.Application.Services.Base
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetOrdersImprove();
        IEnumerable<Customer> GetAllCustomers();
        Order GetOrderById(int id);
        void AddOrder(CreateOrderDto orderDto);
        void UpdateOrder(int id, CreateOrderDto orderDto);
        void DeleteOrder(int id);
    }
}