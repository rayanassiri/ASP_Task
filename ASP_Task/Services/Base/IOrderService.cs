using ASP_Task.Dtos;
using ASP_Task.Models;

namespace ASP_Task.Services.Base
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetOrdersImprove(); 
        IEnumerable<Customer> GetAllCustomers();
        void AddOrder(CreateOrderDto orderDto);
    }
}