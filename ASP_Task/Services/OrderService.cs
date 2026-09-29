using ASP_Task.Dtos;
using ASP_Task.Models;
using ASP_Task.Repositories.Base;
using ASP_Task.Services.Base;
using ASP_Task.Repositories.Base;

namespace ASP_Task.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderDto> GetOrdersImprove() // تم التعديل هنا
        {
            return _unitOfWork.OrderRepo.GetOrdersImprove();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _unitOfWork.CustomerRepo.GetAll();
        }

        public void AddOrder(CreateOrderDto orderDto)
        {
            var order = new Order
            {
                CustomerId = orderDto.CustomerId,
                TotalAmount = orderDto.TotalAmount,
                OrderDate = DateTime.Now
            };

            _unitOfWork.OrderRepo.Add(order);
            _unitOfWork.Save();
        }
    }
}