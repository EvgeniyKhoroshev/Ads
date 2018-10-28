using Authentication.Contracts.CookieAuthentication;
using Authentication.Contracts.JwtAuthentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Authentication.AppServices.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserName(this ClaimsPrincipal principal)
        {
            if (principal == null || !principal.Identity.IsAuthenticated)
                return null;

            switch (principal.Identity.AuthenticationType)
            {
                case CookieAuthenticationDefaults.AuthenticationScheme:
                    return principal.Claims.FirstOrDefault(c => c.Type == CookieCustomClaimNames.UserName)?.Value;
                case JwtBearerDefaults.AuthenticationScheme:
                    return principal.Claims.FirstOrDefault(c => c.Type == JwtCustomClaimNames.UserName)?.Value;
                default:
                    return null;
            }
        }

        public static int? GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null || !principal.Identity.IsAuthenticated)
                return null;

            switch (principal.Identity.AuthenticationType)
            {
                case CookieAuthenticationDefaults.AuthenticationScheme:
                    var cookieId = principal.Claims.FirstOrDefault(c => c.Type == CookieCustomClaimNames.UserId)?.Value;
                    return int.TryParse(cookieId, out var cUserId) ? cUserId : (int?)null;

                case JwtBearerDefaults.AuthenticationScheme:
                    var jwtId = principal.Claims.FirstOrDefault(c => c.Type == JwtCustomClaimNames.UserId)?.Value;
                    return int.TryParse(jwtId, out var jUserId) ? jUserId : (int?)null;

                default:
                    return null;
            }
        }

        public static string GetAuthToken(this ClaimsPrincipal principal)
        {
            if (principal == null || !principal.Identity.IsAuthenticated)
                return null;

            switch (principal.Identity.AuthenticationType)
            {
                case CookieAuthenticationDefaults.AuthenticationScheme:
                    return principal.Claims.FirstOrDefault(c => c.Type == CookieCustomClaimNames.AuthToken)?.Value;
                default:
                    return null;
            }
        }
    }
}
