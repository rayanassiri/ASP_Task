using ASP_Task.Dtos;
using ASP_Task.Models;

namespace ASP_Task.Services.Base
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