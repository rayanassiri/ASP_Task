using ASP_Task.Infrastructure.Data;

namespace ASP_Task.Infrastructure.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;

            CategoryRepo = new CategoryRepository(_db);
            ProductRepo = new ProductRepository(_db);
            CustomerRepo = new CustomerRepository(_db);
            OrderRepo = new OrderRepository(_db);
            SupplierRepo = new SupplierRepository(_db);

        }

        public ICategoryRepository CategoryRepo { get; }
        public IProductRepository ProductRepo { get; }
        public ICustomerRepository CustomerRepo { get; }
        public IOrderRepository OrderRepo { get; }
        public ISupplierRepository SupplierRepo { get; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}