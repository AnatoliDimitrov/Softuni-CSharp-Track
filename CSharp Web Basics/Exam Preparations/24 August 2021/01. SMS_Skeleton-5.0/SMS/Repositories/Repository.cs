namespace SMS.Repositories
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SMS.Data;

    public class Repository : IRepository
    {
        private readonly SMSDbContext context;

        public Repository(SMSDbContext _context)
        {
            this.context = _context;
        }

        public void Add<T>(T entity) where T : class
        {
            this.DbSet<T>().Add(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return this.DbSet<T>().AsQueryable();
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return context.Set<T>();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
