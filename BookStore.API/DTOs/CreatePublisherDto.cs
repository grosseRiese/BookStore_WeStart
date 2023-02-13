using BookStore.API.Extentions;
using Mapster;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs
{
    public class CreatePublisherDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [AdaptIgnore]       //For Mapster
        [AllowExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile Image { get; set; }
    }
}
