using Ads.Contracts.Dto;
using Authentication.Contracts;
using Authentication.Contracts.Basic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.AppServices.CookieAuthentication
{
    /// <summary>
    /// Сервис по аутентификации через куки, основываясь на внешней аутентификации через JWT токен.
    /// </summary>
    public interface IJwtBasedCookieAuthenticationService
    {
        /// <summary>
        /// Выполняет аутентификацию.
        /// </summary>
        Task<AuthenticationResult> SignInAsync(BasicAuthenticationRequest request);

        /// <summary>
        /// Выполняет выход.
        /// </summary>
        Task SignOutAsync();

        /// <summary>
        /// Регистрирует пользователя затем сразу авторизует.
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Результат авторизации</returns>
        Task<AuthenticationResult> SignUpAsync(CreateUserDto user);
    }
}