using Microsoft.AspNetCore.Identity;

namespace web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Ime { get; set; }
        public string? Priimek { get; set; }
        public string? Eposta { get; set; }
    }
}