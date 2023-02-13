namespace BookStore.API.DTOs
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string About { get; set; }
        public IFormFile Image { get; set; }
        public int PublishYear { get; set; }
        public int PageCount { get; set; }
    }
}
