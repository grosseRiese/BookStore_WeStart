using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs
{
    public class LoginRequestDto
    {

        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
