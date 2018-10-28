using Authentication.Contracts.Basic;
using Authentication.Contracts.JwtAuthentication;
using System.Threading.Tasks;

namespace Authentication.AppServices.JwtAuthentication
{
    /// <summary>
    /// Сервис JWT аутентификации.
    /// </summary>
    public interface IJwtAuthenticationService
    {
        /// <summary>
        /// Выполняет аутентификацию.
        /// </summary>
        Task<JwtAuthenticationResult> AuthenticateAsync(BasicAuthenticationRequest request);
    }
}
