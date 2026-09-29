using ASP_Task.Repositories;

namespace ASP_Task.Repositories.Base
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