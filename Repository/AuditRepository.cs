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
            var owners = FindByConditionAndSortByField(audit => audit.DateTime.Year >= auditParameters.startYear &&
                                        audit.DateTime.Year <= auditParameters.endYear,
                                        audit => audit.DateTime);

            return PagedList<Audit>.ToPagedList(owners,
                auditParameters.PageNumber,
                auditParameters.PageSize);
        }
    }
}
