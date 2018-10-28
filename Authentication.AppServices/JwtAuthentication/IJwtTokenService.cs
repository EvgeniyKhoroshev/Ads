using System;
using System.Security.Claims;
using Authentication.Contracts.JwtAuthentication;
using Authentication.Contracts.JwtAuthentication.Options;
using Domain.Entities;

namespace Authentication.AppServices.JwtAuthentication
{
    public interface IJwtTokenService
    {
        JwtAuthenticationToken CreateToken(User user, TimeSpan lifetime);
        Claim[] GetClaims(string authToken);
    }
}