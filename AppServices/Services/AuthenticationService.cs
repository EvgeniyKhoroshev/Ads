using Ads.CoreService.Contracts.Dto;
using AppServices.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
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
        public async Task<string> JWTSignInAsync(UserLoginDto loginDto)
        {
            var signInresult = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password,
                isPersistent: false, lockoutOnFailure: false);
            var User = await _signInManager.UserManager.FindByNameAsync(loginDto.UserName);
            if (signInresult.Succeeded)
            {
                var claimsPrincipal = await _signInManager.ClaimsFactory.CreateAsync(User);
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("C - 137@# Try To Encode"));
                var signinCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44396",
                    audience: "https://localhost:44382",
                    claims: claimsPrincipal.Claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;
            }
            else
            {
                return "";
            }
        }
        public string GetToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("C - 137@# Try To Encode"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
        public async Task SignOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
