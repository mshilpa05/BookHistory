using BookHistory.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookHistory.Repository
{
    public class AuditRepository : RepositoryBase<Audit>, IAuditRepository
    {
        public AuditRepository(BookContext bookContext)
            : base(bookContext)
        {
        }

        public async Task<IEnumerable<Audit>> GetAuditsAsync(AuditParameters auditParameters)
        {
            return PagedList<Audit>.ToPagedList(FindAll(),
                auditParameters.PageNumber,
                auditParameters.PageSize);
        }
    }
}
