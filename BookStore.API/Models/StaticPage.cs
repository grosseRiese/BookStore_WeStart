using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models
{
    public class StaticPage
    {
        [Key]
        public int Id { get; set; }
        public string PageName { get; set; }
        public string Details { get; set; }
    }
}
