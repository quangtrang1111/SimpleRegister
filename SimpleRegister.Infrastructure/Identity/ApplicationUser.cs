using Microsoft.AspNetCore.Identity;

namespace SimpleRegister.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }
    }
}
