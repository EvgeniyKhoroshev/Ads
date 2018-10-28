using System;
using System.Threading.Tasks;
using Authentication.Contracts.Basic;
using Authentication.Contracts.JwtAuthentication;
using Authentication.Contracts.JwtAuthentication.Options;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Authentication.AppServices.JwtAuthentication
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtServerAuthenticationOptions _authenticationOptions;
        private readonly IJwtTokenService _tokenService;

        public JwtAuthenticationService(
            UserManager<User> userManager,
            IJwtTokenService tokenService,
            IOptions<JwtServerAuthenticationOptions> authenticationOptions)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _authenticationOptions = authenticationOptions.Value;
        }

        public async Task<JwtAuthenticationResult> AuthenticateAsync(BasicAuthenticationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var identity = await _userManager.FindByNameAsync(request.Username);
            if (identity == null)
                return JwtAuthenticationResult.Failed("User not found");

            var isPasswordMatched = await _userManager.CheckPasswordAsync(identity, request.Password);
            if (!isPasswordMatched)
                return JwtAuthenticationResult.Failed("Invalid username or password");
            var token = _tokenService.CreateToken(identity, _authenticationOptions.Lifetime);
            return JwtAuthenticationResult.Succeed(token);
        }
    }
}