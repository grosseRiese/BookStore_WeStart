namespace BookStore.API.DTOs
{
    public class CreateBookReviewDto
    {
        public int BookId { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public string AppUserId { get; set; }
    }
}
