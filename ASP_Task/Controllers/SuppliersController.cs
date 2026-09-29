using Microsoft.AspNetCore.Mvc;
using ASP_Task.Dtos;
using ASP_Task.Services.Base;

namespace ASP_Task.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public IActionResult Index()
        {
            var suppliers = _supplierService.GetAllSuppliers();
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
                _supplierService.AddSupplier(supplierDto);
                return RedirectToAction("Index");
            }
            return View(supplierDto);
        }

        public IActionResult Edit(int id)
        {
            var supplier = _supplierService.GetSupplierById(id);
            if (supplier == null) return NotFound();

            var supplierDto = new CreateSupplierDto
            {
                Name = supplier.Name,
                ContactEmail = supplier.ContactEmail,
                Phone = supplier.Phone
            };

            return View(supplierDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreateSupplierDto supplierDto)
        {
            if (ModelState.IsValid)
            {
                _supplierService.UpdateSupplier(id, supplierDto);
                return RedirectToAction("Index");
            }
            return View(supplierDto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _supplierService.DeleteSupplier(id);
            return RedirectToAction("Index");
        }
    }
}