using Ads.CoreService.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        string GetToken();
        Task<string> JWTSignInAsync(UserLoginDto loginDto);
        /// <summary>
        /// Сервис для авторизации пользователя /
        /// User authorization service
        /// </summary>
        /// <param name="userLoginDto">Данные, необходимые для входа / 
        /// Data for user sign in</param>
        Task SignInUserAsync(UserLoginDto userLoginDto);
        /// <summary>
        /// Сервис для выхода из учетной записи для текущего пользователя /
        /// User sign out service
        /// </summary>
        Task SignOutUserAsync();
    }
}
