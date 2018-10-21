using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<User> _signInManager;

        public AuthenticationService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task SignInUserAsync(UserLoginDto userLoginDto)
        {
            if (userLoginDto == null)
                throw new ArgumentNullException(nameof(userLoginDto));

            var result = await _signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
                throw new InvalidOperationException("Некорректный логин или пароль.");
        }

        public async Task SignOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
