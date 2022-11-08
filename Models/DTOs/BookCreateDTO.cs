namespace BookHistory.Models.DTOs
{
    public class BookCreateDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime PublishDate { get; set; }
        public string? Author { get; set; }
    }
}
