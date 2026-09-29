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
    }
}