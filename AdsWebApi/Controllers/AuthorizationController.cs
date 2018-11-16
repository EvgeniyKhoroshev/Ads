using Ads.CoreService.Contracts.Dto;
using Ads.CoreService.Contracts.Dto.Filters;
using AppServices.ServiceInterfaces;
using Authentication.AppServices.JwtAuthentication;
using Authentication.Contracts.Basic;
using Authentication.Contracts.JwtAuthentication;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        public AuthorizationController(
            IUserService userService,
            IAuthenticationService authenticationService,
            IJwtAuthenticationService JwtAuthenticationService)
        {
            _JwtAuthenticationService = JwtAuthenticationService;
            _authenticationService = authenticationService;
            _userService = userService;
        }
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IJwtAuthenticationService _JwtAuthenticationService;
        [HttpPost("authenticate")]
        public async Task<ActionResult<JwtAuthenticationToken>> Authenticate(BasicAuthenticationRequest request)
        {
            if (request == null)
                return BadRequest();

            var result = await _JwtAuthenticationService.AuthenticateAsync(request);
            if (!result.IsSucceed)
                return BadRequest(result.Errors);

            return Ok(result.Token);
        }
        [HttpPost("SignUp")]
        public async Task SignUp([FromBody] CreateUserDto value)
        {
            await _userService.CreateUserAsync(value);
        }
        [HttpGet("signout")]
        public async Task SignOut()
        {
            await _authenticationService.SignOutUserAsync();
        }
        [HttpPost("ChangeAvatar")]
        public async Task ChangeAvatarAsync(UserAvatarDto avatar)
        {
            await _userService.ChangeAvatarAsync(avatar);
        }
        [HttpGet("GetUserInfo/{userId}")]
        public async Task<IActionResult> GetUserInfo(int userId)
        {
            var s = await _userService.GetUserInfoAsync(userId);
            return Ok(s);
        }
    }
}
