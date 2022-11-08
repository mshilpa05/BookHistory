using System.ComponentModel.DataAnnotations.Schema;

namespace BookHistory.Models
{
    public class Book
    {
        public string Id { get; set; } = String.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime PublishDate { get; set; }
        public string? Author { get; set; }
    }
}