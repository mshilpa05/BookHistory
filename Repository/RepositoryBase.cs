using BookHistory.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookHistory.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected BookContext BookContext { get; set; }

        public RepositoryBase(BookContext repositoryContext)
        {
            this.BookContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.BookContext.Set<T>()
                .AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.BookContext.Set<T>()
                .Where(expression)
                .AsNoTracking();
        }

        public void Create(T entity)
        {
            this.BookContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.BookContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.BookContext.Set<T>().Remove(entity);
        }
    }
}
