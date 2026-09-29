using Microsoft.AspNetCore.Mvc;
using ASP_Task.Dtos;
using ASP_Task.Services.Base;

namespace ASP_Task.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var customers = _customerService.GetAllCustomers();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                _customerService.AddCustomer(customerDto);
                return RedirectToAction("Index");
            }

            return View(customerDto);
        }
    }
}