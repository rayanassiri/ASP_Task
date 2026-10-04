using ASP_Task.Infrastructure.Data;
using ASP_Task.Domain.Models;

namespace ASP_Task.Infrastructure.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDbContext db) : base(db)
        {
        }
    }
}