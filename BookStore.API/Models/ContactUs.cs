using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Models
{
    [Keyless]
    public class ContactUs
    {
        public string Email { get; set; }
        public string Message { get; set; }
        public string FullName { get; set; }
        public DateTime ReadAt { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
    }
}
