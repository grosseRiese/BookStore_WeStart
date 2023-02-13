namespace BookStore.API.DTOs
{
    public class CreateSalesDto
    {
        public string AppUserId { get; set; }
        public int BookId { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; } = new DateTime( DateTime.Now.Year,
                                                                DateTime.Now.Month,
                                                                DateTime.Now.Day );
        public decimal TotalPrice { get; set; }
    }
}
