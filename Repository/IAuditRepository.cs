using BookHistory.Models;
using BookHistory.Repository;

namespace BookHistory.Repository
{
    public interface IAuditRepository : IRepositoryBase<Audit>
    {
        Task<IEnumerable<Audit>> GetAuditsAsync(QueryStringParameters auditParameters);
    }
}


