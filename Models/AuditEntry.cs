using BookHistory.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace BookHistory.Models
{
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }
        public EntityEntry Entry { get; }
        public string KeyValue { get; set; } = string.Empty;    
        public string Values { get; set; } = string.Empty;
        public AuditType AuditType { get; set; }
        public string ChangedColumns { get; set; } = string.Empty; 
        public Audit ToAudit()
        {
            var audit = new Audit
            {
                Type = AuditType.ToString(),
                DateTime = DateTime.Now,
                BookId = KeyValue,
                Values = Values,
                AffectedColumns = ChangedColumns
            };
            return audit;
        }
    }
}
