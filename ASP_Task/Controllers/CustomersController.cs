using Microsoft.AspNetCore.Mvc;
using ASP_Task.Dtos;
using ASP_Task.Models;
using ASP_Task.Repositories;

namespace ASP_Task.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var customers = _customerRepository.GetAll();
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
                var customer = new Customer
                {
                    Name = customerDto.Name,
                    Email = customerDto.Email,
                    Phone = customerDto.Phone
                };

                _customerRepository.Add(customer);
                _customerRepository.Save();
                return RedirectToAction("Index");
            }

            return View(customerDto);
        }
    }
}