using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.API.Models
{
    public class BookReviews
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; } = "73411vq6-935r-99bo-7w52-kmo9eq72k8356";
        public AppUser AppUser { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
