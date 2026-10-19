using ASP_Task.Infrastructure.Data;
using ASP_Task.Domain.Models;

namespace ASP_Task.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext db) : base(db)
        {
        }
    }
}