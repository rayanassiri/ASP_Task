using ASP_Task.Data;
using ASP_Task.Models;

namespace ASP_Task.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext db) : base(db)
        {
        }
    }
}