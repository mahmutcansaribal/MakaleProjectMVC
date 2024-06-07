using MakaleProject.Models.Context;
using MakaleProject.Models.RepositoryDesignPattern.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MakaleProject.Models.RepositoryDesignPattern
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ArticleDbContext _articleDbContext;
        internal DbSet<T> dbSet;

        public Repository(ArticleDbContext articleDbContext)
        {
            _articleDbContext = articleDbContext;
            this.dbSet = _articleDbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void DeleteById(T entity)
        {
            dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void SaveDb()
        {
            _articleDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
