using SimpleRegister.Application.Models;
using System.Threading.Tasks;

namespace SimpleRegister.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<string> CreateAccountAsync(UserModel user, string password);

        Task<bool> ConfirmEmailThenSignInAsync(string email, string token);

        UserModel GetAccountProfile(string email);
    }
}
