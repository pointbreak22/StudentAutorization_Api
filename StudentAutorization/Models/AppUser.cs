using Microsoft.AspNetCore.Identity;

namespace StudentAutorization.Models
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }


    }
}
