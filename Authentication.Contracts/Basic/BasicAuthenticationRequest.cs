using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Contracts.Basic
{

    /// <summary>
    /// Запрос на выполнение Basic-authentication.
    /// </summary>

    public class BasicAuthenticationRequest
    {

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }
    }
}
