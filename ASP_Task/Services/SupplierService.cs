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

        public Supplier GetSupplierById(int id)
        {
            return _unitOfWork.SupplierRepo.GetById(id);
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

        public void UpdateSupplier(int id, CreateSupplierDto supplierDto)
        {
            var supplier = _unitOfWork.SupplierRepo.GetById(id);
            if (supplier != null)
            {
                supplier.Name = supplierDto.Name;
                supplier.ContactEmail = supplierDto.ContactEmail;
                supplier.Phone = supplierDto.Phone;

                _unitOfWork.SupplierRepo.Update(supplier);
                _unitOfWork.Save();
            }
        }

        public void DeleteSupplier(int id)
        {
            _unitOfWork.SupplierRepo.Delete(id);
            _unitOfWork.Save();
        }
    }
}