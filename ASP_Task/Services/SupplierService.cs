using ASP_Task.Dtos;
using ASP_Task.Models;
using ASP_Task.Repositories.Base;
using ASP_Task.Services.Base;

namespace ASP_Task.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return _unitOfWork.SupplierRepo.GetAll();
        }

        public void AddSupplier(CreateSupplierDto supplierDto)
        {
            var supplier = new Supplier
            {
                Name = supplierDto.Name,
                ContactEmail = supplierDto.ContactEmail,
                Phone = supplierDto.Phone
            };

            _unitOfWork.SupplierRepo.Add(supplier);
            _unitOfWork.Save();
        }
    }
}