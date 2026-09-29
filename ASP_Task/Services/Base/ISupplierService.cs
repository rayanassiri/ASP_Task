using ASP_Task.Dtos;
using ASP_Task.Models;

namespace ASP_Task.Services.Base
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