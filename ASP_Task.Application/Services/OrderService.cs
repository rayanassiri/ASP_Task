using ASP_Task.Application.Dtos;
using ASP_Task.Domain.Models;
using ASP_Task.Infrastructure.Repositories.Base;
using ASP_Task.Application.Services.Base;

namespace ASP_Task.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderDto> GetOrdersImprove()
        {
            return _unitOfWork.OrderRepo.GetOrdersImprove();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _unitOfWork.CustomerRepo.GetAll();
        }

        public Order GetOrderById(int id)
        {
            return _unitOfWork.OrderRepo.GetById(id);
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

        public void UpdateOrder(int id, CreateOrderDto orderDto)
        {
            var order = _unitOfWork.OrderRepo.GetById(id);
            if (order != null)
            {
                order.CustomerId = orderDto.CustomerId;
                order.TotalAmount = orderDto.TotalAmount;

                _unitOfWork.OrderRepo.Update(order);
                _unitOfWork.Save();
            }
        }

        public void DeleteOrder(int id)
        {
            _unitOfWork.OrderRepo.Delete(id);
            _unitOfWork.Save();
        }
    }
}