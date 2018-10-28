using Authentication.AppServices.JwtAuthentication;
using Authentication.Contracts.JwtAuthentication;
using Authentication.Contracts.JwtAuthentication.Options;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Authentication.AppServices.JwtAuthentication
{
    /// <summary>
    /// Сервис для работы с JWT токенами.
    /// </summary>
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly JwtBaseAuthenticationOptions _authenticationOptions;

        public JwtTokenService(IOptions<JwtBaseAuthenticationOptions> authenticationOptions)
        {
            _tokenHandler = new JwtSecurityTokenHandler();
            _authenticationOptions = authenticationOptions.Value;
        }

        /// <inheritdoc />
        public JwtAuthenticationToken CreateToken(User user, TimeSpan lifetime)
        {
            try
            {
                var descriptor = new SecurityTokenDescriptor
                {
                    Audience = _authenticationOptions.Audience,
                    Issuer = _authenticationOptions.Issuer,
                    Expires = DateTime.UtcNow.Add(lifetime),
                    SigningCredentials = JwtDefaultsProvider.GetSigningCredentials(_authenticationOptions.Secret),
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("D")), 
                    
                    // Сюда мы можем записать любые заявки, которые хотим передавать в токене
                    new Claim(JwtCustomClaimNames.UserId, user.Id.ToString()),
                    new Claim(JwtCustomClaimNames.UserName, user.Email),

                }, JwtBearerDefaults.AuthenticationScheme)
                };

                var token = _tokenHandler.CreateToken(descriptor);

                return new JwtAuthenticationToken
                {
                    AuthToken = _tokenHandler.WriteToken(token),
                    Expires = descriptor.Expires,
                    UserId = user.Id
                };
            }
            catch (Exception ex)
            {
                string err = "Something went wrong during Jwt generation" + ex.Message;
                throw new InvalidOperationException(string.Join(Environment.NewLine, err));
            }
        }
        /// <inheritdoc />
        public Claim[] GetClaims(string authToken)
        {
            if (string.IsNullOrEmpty(authToken))
                throw new ArgumentNullException(nameof(authToken));

            if (!_tokenHandler.CanReadToken(authToken))
                throw new ArgumentException("Token is not well formatted JWT");

            try
            {
                var validationParams = JwtDefaultsProvider.GetTokenValidationParameters(
                    _authenticationOptions.Issuer,
                    _authenticationOptions.Audience,
                    _authenticationOptions.Secret);

                var principal = _tokenHandler.ValidateToken(authToken, validationParams, out _);
                return principal.Claims.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}