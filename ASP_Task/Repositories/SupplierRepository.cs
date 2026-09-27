using ASP_Task.Data;
using ASP_Task.Models;

namespace ASP_Task.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDbContext db) : base(db)
        {
        }
    }
}