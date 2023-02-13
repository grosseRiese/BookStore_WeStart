using Microsoft.AspNetCore.Identity;

namespace BookStore.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public List<UserFavs> UserFavs { get; set; }
        public List<Sales> Sales { get; set; }
    }
}
