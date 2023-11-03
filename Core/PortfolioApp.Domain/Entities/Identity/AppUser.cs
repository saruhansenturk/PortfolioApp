

using Microsoft.AspNetCore.Identity;

namespace PortfolioApp.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string NameSurname { get; set; }
    }
}
