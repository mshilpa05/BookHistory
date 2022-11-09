using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BookHistory.Models
{
    public class AuditableIdentityContext : IdentityDbContext
    {
        public AuditableIdentityContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Audit> AuditLogs { get; set; }

        public virtual async Task<int> SaveChangesAsync()
        {
            CreateAuditEntryBeforeSavingChanges();
            var result = await base.SaveChangesAsync();
            return result;
        }

        private void CreateAuditEntryBeforeSavingChanges()
        {
            //ChangeTracker.DetectChanges();

            var auditEntries = new List<AuditEntry>();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry(entry);
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;

                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValue = property.CurrentValue as string;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = Enums.AuditType.Create;
                            auditEntry.Values = auditEntry.Values + $"{propertyName}:{property.CurrentValue} ";
                            break;

                        case EntityState.Deleted:
                            auditEntry.AuditType = Enums.AuditType.Delete;
                            break;

                        case EntityState.Modified:
                            var originalValue = entry.GetDatabaseValues()?.GetValue<object>(propertyName);
                            if (!string.Equals(property.CurrentValue, originalValue))
                            {
                                auditEntry.ChangedColumns = auditEntry.ChangedColumns + $"{propertyName} ";
                                auditEntry.AuditType = Enums.AuditType.Update;
                                auditEntry.Values = auditEntry.Values + $"{propertyName}: {property.CurrentValue} ";
                            }
                            break;
                    }
                }
            }

            foreach (var auditEntry in auditEntries)
            {
                AuditLogs.Add(auditEntry.ToAudit());
            }
        }
    }
}
