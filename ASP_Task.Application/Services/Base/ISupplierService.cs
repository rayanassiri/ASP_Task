using ASP_Task.Application.Dtos;
using ASP_Task.Domain.Models;

namespace ASP_Task.Application.Services.Base
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAllSuppliers();
        Supplier GetSupplierById(int id);
        void AddSupplier(CreateSupplierDto supplierDto);
        void UpdateSupplier(int id, CreateSupplierDto supplierDto);
        void DeleteSupplier(int id);
    }
}