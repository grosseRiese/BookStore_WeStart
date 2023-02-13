using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.API.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        public int amount { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Order_date { get; set; }
        public decimal TotalPrice { get; set; }
        public IsSoldStatus IsSold { get; set; } = 0;
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime SoldDate { get; set; }
    }
    public enum IsSoldStatus
    {
        ok = 1,
        notOk = 0
    }
}
