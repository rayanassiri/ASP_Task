using ASP_Task.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP_Task.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public IEnumerable<T> GetAll() => dbSet.ToList();
        public T GetById(int id) => dbSet.Find(id);
        public void Add(T entity) => dbSet.Add(entity);
        public void Update(T entity) => dbSet.Update(entity);
        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null) dbSet.Remove(entity);
        }
        public void Save() => _db.SaveChanges();
    }
}