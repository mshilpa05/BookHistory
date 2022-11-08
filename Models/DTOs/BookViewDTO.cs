using System.ComponentModel.DataAnnotations.Schema;

namespace BookHistory.Models.DTOs
{
    public class BookViewDTO
    {
            public string Id { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }
            public DateTime PublishDate { get; set; }
            public string? Author { get; set; }
    }
}
