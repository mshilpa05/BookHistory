﻿using BookHistory.Models;
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
            var owners = FindByConditionAndSortByField(audit => audit.DateTime.Year >= auditParameters.StartYear &&
                                        audit.DateTime.Year <= auditParameters.EndYear,
                                        audit => audit.DateTime);

            return PagedList<Audit>.ToPagedList(owners,
                auditParameters.PageNumber,
                auditParameters.PageSize);
        }
    }
}
