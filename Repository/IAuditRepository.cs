using BookHistory.Models;
using BookHistory.Models.DTOs;
using BookHistory.Repository;

namespace BookHistory.Repository
{
    public interface IAuditRepository : IRepositoryBase<Audit>
    {
        Task<IEnumerable<Audit>> GetAuditsAsync(AuditParameters auditParameters);

        Task<IEnumerable<AuditGroupedByBookId>> GetActionCount();
    }
}


