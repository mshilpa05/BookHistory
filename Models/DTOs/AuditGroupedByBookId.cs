namespace BookHistory.Models.DTOs
{
    public class AuditGroupedByBookId
    {
        public string? BookId { get; set; } 

        public int AuditLogCount { get; set; }
    }
}
