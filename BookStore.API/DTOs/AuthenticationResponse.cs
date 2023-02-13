namespace BookStore.API.DTOs
{
    public class AuthenticationResponse
    {
        public string? Token { get; set; } = String.Empty;
        public DateTime Expiration { get; set; }
        public string UserId { get; set; }
    }
}
