using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP_Task.Dtos;
using ASP_Task.Models;
using ASP_Task.Repositories;

namespace ASP_Task.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrdersController(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var orders = _orderRepository.GetOrdersImprove();
            return View(orders);
        }

        public IActionResult Create()
        {
            var allCustomers = _customerRepository.GetAll();
            ViewBag.Customers = new SelectList(allCustomers, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateOrderDto orderDto)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    CustomerId = orderDto.CustomerId,
                    TotalAmount = orderDto.TotalAmount,
                    OrderDate = DateTime.Now
                };

                _orderRepository.Add(order);
                _orderRepository.Save();
                return RedirectToAction("Index");
            }

            var allCustomers = _customerRepository.GetAll();
            ViewBag.Customers = new SelectList(allCustomers, "Id", "Name");
            return View(orderDto);
        }
    }
}