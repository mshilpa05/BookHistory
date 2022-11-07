using System.ComponentModel.DataAnnotations.Schema;

namespace BookHistory.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime PublishDate { get; set; }
        public string? Author { get; set; }
    }
}