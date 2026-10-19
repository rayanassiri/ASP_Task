using ASP_Task.Application.Services.Base;
using ASP_Task.Application.Services;

namespace ASP_Task.Infrastructure.Repositories 

{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepo { get; }
        ICustomerRepository CustomerRepo { get; }
        IProductRepository ProductRepo { get; }
        IOrderRepository OrderRepo { get; }
        ISupplierRepository SupplierRepo { get; }

        void Save();
    }
}