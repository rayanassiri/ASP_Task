using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP_Task.Dtos;
using ASP_Task.Services.Base;

namespace ASP_Task.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var orders = _orderService.GetOrdersImprove();
            return View(orders);
        }

        public IActionResult Create()
        {
            var allCustomers = _orderService.GetAllCustomers();
            ViewBag.Customers = new SelectList(allCustomers, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateOrderDto orderDto)
        {
            if (ModelState.IsValid)
            {
                _orderService.AddOrder(orderDto);
                return RedirectToAction("Index");
            }

            var allCustomers = _orderService.GetAllCustomers();
            ViewBag.Customers = new SelectList(allCustomers, "Id", "Name");
            return View(orderDto);
        }

        public IActionResult Edit(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null) return NotFound();

            var orderDto = new CreateOrderDto
            {
                CustomerId = order.CustomerId,
                TotalAmount = order.TotalAmount
            };

            var allCustomers = _orderService.GetAllCustomers();
            ViewBag.Customers = new SelectList(allCustomers, "Id", "Name", order.CustomerId);
            return View(orderDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreateOrderDto orderDto)
        {
            if (ModelState.IsValid)
            {
                _orderService.UpdateOrder(id, orderDto);
                return RedirectToAction("Index");
            }

            var allCustomers = _orderService.GetAllCustomers();
            ViewBag.Customers = new SelectList(allCustomers, "Id", "Name", orderDto.CustomerId);
            return View(orderDto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _orderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}