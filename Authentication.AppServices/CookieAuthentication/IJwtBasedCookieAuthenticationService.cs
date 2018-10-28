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
    }
}