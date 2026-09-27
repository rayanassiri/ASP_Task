using Microsoft.AspNetCore.Mvc;
using ASP_Task.Dtos;
using ASP_Task.Models;
using ASP_Task.Repositories;

namespace ASP_Task.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;

        public SuppliersController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public IActionResult Index()
        {
            var suppliers = _supplierRepository.GetAll();
            return View(suppliers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateSupplierDto supplierDto)
        {
            if (ModelState.IsValid)
            {
                var supplier = new Supplier
                {
                    Name = supplierDto.Name,
                    ContactEmail = supplierDto.ContactEmail,
                    Phone = supplierDto.Phone
                };

                _supplierRepository.Add(supplier);
                _supplierRepository.Save();
                return RedirectToAction("Index");
            }

            return View(supplierDto);
        }
    }
}