namespace CarShop.Repositories
{
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using CarShop.Data;

    public class Repository : IRepository
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext _context)
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
