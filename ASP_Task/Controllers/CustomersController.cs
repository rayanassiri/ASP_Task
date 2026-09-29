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

        public IActionResult Edit(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null) return NotFound();

            var customerDto = new CreateCustomerDto
            {
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone
            };

            return View(customerDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreateCustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                _customerService.UpdateCustomer(id, customerDto);
                return RedirectToAction("Index");
            }
            return View(customerDto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _customerService.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}