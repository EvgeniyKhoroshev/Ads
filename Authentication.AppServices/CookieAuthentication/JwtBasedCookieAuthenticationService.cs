using Authentication.AppServices.JwtAuthentication;
using Authentication.Contracts;
using Authentication.Contracts.Basic;
using Authentication.Contracts.CookieAuthentication;
using Authentication.Contracts.JwtAuthentication;
using Authentication.Contracts.JwtAuthentication.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authentication.AppServices.CookieAuthentication
{
    public class JwtBasedCookieAuthenticationService : IDisposable, IJwtBasedCookieAuthenticationService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IJwtTokenService _tokenService;
        private readonly HttpClient _httpClient;
        private readonly JwtClientAuthenticationOptions _jwtOptions;

        public JwtBasedCookieAuthenticationService(
            IHttpContextAccessor contextAccessor,
            IOptions<JwtClientAuthenticationOptions> authOptions,
            IJwtTokenService tokenService)
        {
            _contextAccessor = contextAccessor;
            _tokenService = tokenService;
            _jwtOptions = authOptions.Value;
            _httpClient = new HttpClient();
        }

        /// <inheritdoc />
        public async Task<AuthenticationResult> SignInAsync(BasicAuthenticationRequest request)
        {
            try
            {
                var context = _contextAccessor.HttpContext;
                if (context == null)
                    throw new InvalidOperationException("No http context provided");

                var response = await _httpClient.PostAsJsonAsync(_jwtOptions.AuthenticationEndpoint, request);
                if (!response.IsSuccessStatusCode)
                    return AuthenticationResult.Failed("Unable to get JWT token");

                var token = await response.Content.ReadAsAsync<JwtAuthenticationToken>();
                if (token == null || token.AuthToken == null)
                    return AuthenticationResult.Failed("Token is null");

                var cookieIdentity = new ClaimsIdentity(new[]
                {
                new Claim(CookieCustomClaimNames.AuthToken, token.AuthToken),
                new Claim(CookieCustomClaimNames.UserId, token.UserId.ToString())

            }, CookieAuthenticationDefaults.AuthenticationScheme);

                // Добавляем клеймы из токена
                var jwtClaims = _tokenService.GetClaims(token.AuthToken);
                var userNameClaim = jwtClaims?.FirstOrDefault(c => c.Type == JwtCustomClaimNames.UserName);
                if (userNameClaim != null)
                    cookieIdentity.AddClaim(new Claim(CookieCustomClaimNames.UserName, userNameClaim.Value));

                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(cookieIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = false,
                        ExpiresUtc = token.Expires
                    });

                return AuthenticationResult.Succeed;
            }
            catch (Exception ex)
            {
                string err = "err" + ex.Message;
                throw new Exception(string.Join(Environment.NewLine, err));
            }
        }

        /// <inheritdoc />
        public async Task SignOutAsync()
        {
            var context = _contextAccessor.HttpContext;
            if (context == null)
                throw new InvalidOperationException("No http context provided");

            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
