using System.Linq.Expressions;

namespace BookHistory.Repository
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindByConditionAndSortByField(Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, DateTime>> orderByExpression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

