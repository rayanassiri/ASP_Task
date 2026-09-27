using ASP_Task.Data;
using ASP_Task.Models;

namespace ASP_Task.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext db) : base(db)
        {
        }
    }
}