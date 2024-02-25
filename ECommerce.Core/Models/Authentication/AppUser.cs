
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Core.Models.Authentication
{
    public class AppUser : IdentityUser
    {
        public string City { get; set; }
    }
}
