using Microsoft.AspNetCore.Identity;

namespace StudentAutorization.Models.Autorization
{

    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public List<IdentityRole> Roles { get; } = new List<IdentityRole>();



    }
}
