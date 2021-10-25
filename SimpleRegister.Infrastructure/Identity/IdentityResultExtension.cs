using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace SimpleRegister.Infrastructure.Identity
{
    public static class IdentityResultExtension
    {
        public static string ParseErrorString(this IdentityResult result)
        {
            return string.Join("; ", result.Errors.Select(e => e.Description));
        }
    }
}
