using BookStore.API.Extentions;
using Mapster;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs
{
    public class UpdatePublisherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [AdaptIgnore]
        [AllowExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile Logo { get; set; }
    }
}
