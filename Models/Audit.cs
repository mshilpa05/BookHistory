using System.ComponentModel.DataAnnotations.Schema;

namespace BookHistory.Models
{
    public class Audit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Type { get; set; }
        public DateTime DateTime { get; set; }
        public string? Values { get; set; }
        public string? AffectedColumns { get; set; }
        public long BookId { get; set; }
    }
}
