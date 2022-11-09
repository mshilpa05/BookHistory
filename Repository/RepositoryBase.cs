using BookHistory.Models;
using BookHistory.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookHistory.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly BookContext _bookContext;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(BookContext bookContext)
        {
            _bookContext = bookContext;
            _dbSet = _bookContext.Set<T>();
        }

        public IQueryable<T> FindAll()
        {
            return _dbSet
                .AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet
                .Where(expression)
                .AsNoTracking();
        }

        public async Task<List<T>> FindByConditionAndSortByField(Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, DateTime>> orderByExpression)

        {
            return await _dbSet
                .Where(filterExpression)
                .OrderBy(orderByExpression)
                .AsNoTracking().ToListAsync();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
