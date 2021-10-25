using Mapster;
using Microsoft.AspNetCore.Identity;
using SimpleRegister.Application.Interfaces;
using SimpleRegister.Application.Models;
using SimpleRegister.Infrastructure.Exceptions;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRegister.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> CreateAccountAsync(UserModel userModel, string password)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Email == userModel.Email);
            if (user != null)
            {
                throw new IdentityException("User email is already taken");
            }

            var appUser = userModel.Adapt<ApplicationUser>();
            appUser.UserName = userModel.Email;

            var result = await _userManager.CreateAsync(appUser, password);
            if (!result.Succeeded)
            {
                throw new IdentityException(result.ParseErrorString());
            }

            user = _userManager.Users.SingleOrDefault(u => u.Email == userModel.Email);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return token;
        }

        public async Task<bool> ConfirmEmailThenSignInAsync(string email, string token)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Email == email);
            if (user == null)
            {
                throw new IdentityException("User is not found!");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                throw new IdentityException(result.ParseErrorString());
            }

            await _signInManager.SignInAsync(user, true);

            return result.Succeeded;
        }

        public UserModel GetAccountProfile(string email)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Email == email);
            if (user == null)
            {
                throw new IdentityException("User is not found!");
            }

            return user.Adapt<UserModel>();
        }
    }
}
