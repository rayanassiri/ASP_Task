using ASP_Task.Infrastructure.Data;
using ASP_Task.Domain.Models;
using ASP_Task.Data;

namespace ASP_Task.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext db;

        public CategoryRepository(AppDbContext db) : base(db)
        {
        }

        public CategoryRepository(AppDbContext db)
        {
            this.db = db;
        }
    }
}