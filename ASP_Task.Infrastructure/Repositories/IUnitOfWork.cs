using ASP_Task.Infrastructure.Repositories;

namespace ASP_Task.Infrastructure.Repositories.Base
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