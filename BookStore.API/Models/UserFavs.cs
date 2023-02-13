using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.API.Models
{
    public class UserFavs
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
