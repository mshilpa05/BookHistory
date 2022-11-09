using BookHistory.Models;
using BookHistory.Models.DTOs;
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
            List<Audit> audits;
            if (string.IsNullOrEmpty(auditParameters.BookId)) {
                audits = await FindByConditionAndSortByField(audit => audit.DateTime.Year >= auditParameters.StartYear &&
                                        audit.DateTime.Year <= auditParameters.EndYear,
                                        audit => audit.DateTime).ToListAsync();
            }
            else
            {
                audits = await FindByConditionAndSortByField(audit => audit.DateTime.Year >= auditParameters.StartYear &&
                                        audit.DateTime.Year <= auditParameters.EndYear &&
                                        audit.BookId == auditParameters.BookId,
                                        audit => audit.DateTime).ToListAsync();
            }

            return PagedList<Audit>.ToPagedList(audits,
                auditParameters.PageNumber,
                auditParameters.PageSize);
        }

        public async Task<IEnumerable<AuditGroupedByBookId>> GetActionCount()
        {
            return await FindAll()
                .GroupBy(a => a.BookId)
                .Select(a => new AuditGroupedByBookId { BookId = a.Key, AuditLogCount = a.Count() })
                .ToListAsync();
        }
    }
}
