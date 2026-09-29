using ASP_Task.Dtos;
using ASP_Task.Models;

namespace ASP_Task.Services.Base
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAllSuppliers();
        void AddSupplier(CreateSupplierDto supplierDto);
    }
}