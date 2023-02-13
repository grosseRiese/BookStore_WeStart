using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.API.DTOs
{
    public class RegisterRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
