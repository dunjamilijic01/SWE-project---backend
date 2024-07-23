using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class AppUser: IdentityUser<int>
    {
        public string Ime { get; set; } 
        public string Prezime { get; set; }

    }
}
