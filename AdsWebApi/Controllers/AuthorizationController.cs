using Ads.Contracts.Dto;
using Ads.Contracts.Dto.Filters;
using AppServices.ServiceInterfaces;
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
        public AuthorizationController(IUserService userService, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        [HttpPost("create")]
        public async Task TaskCreateUser([FromBody] CreateUserDto value)
        {
            await _userService.CreateUserAsync(value);
        }
        [HttpGet("signout")]
        public async Task SignOut()
        {
            await _authenticationService.SignOutUserAsync();
        }
        // Sign in without jwt (dont used anymore)
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] UserLoginDto value)
        {
            
            var s = await _authenticationService.JWTSignInAsync(value);
            return Ok(s);
        }
    }
}
