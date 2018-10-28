using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Authentication.AppServices.JwtAuthentication
{
    /// <summary>
    /// Провайдер значений для JWT.
    /// </summary>
    public static class JwtDefaultsProvider
    {
        /// <summary>
        /// Возвращает ключ подписи.
        /// </summary>
        public static SecurityKey GetSecurityKey(string secret)
        {
            if (string.IsNullOrEmpty(secret))
                throw new ArgumentNullException(nameof(secret));

            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        }

        /// <summary>
        /// Возвращает параметры для подписи
        /// </summary>
        public static SigningCredentials GetSigningCredentials(string secret)
        {
            if (string.IsNullOrEmpty(secret))
                throw new ArgumentNullException(nameof(secret));

            return new SigningCredentials(GetSecurityKey(secret), SecurityAlgorithms.HmacSha256);
        }

        /// <summary>
        /// Возвращает параметры для валидации JWT токена.
        /// </summary>
        public static TokenValidationParameters GetTokenValidationParameters(string issuer, string audience, string secret)
        {
            return new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                ClockSkew = TimeSpan.Zero,
                AuthenticationType = JwtBearerDefaults.AuthenticationScheme,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
            };
        }
    }
}