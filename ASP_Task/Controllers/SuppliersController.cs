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
    }
}