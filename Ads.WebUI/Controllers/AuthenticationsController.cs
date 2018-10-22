using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ads.WebUI.Controllers
{
    public class AuthenticationsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationsController(IUserService userService, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }
        [HttpGet]
        public IActionResult SignIn() => View();
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto user)
        {

            await _authenticationService.SignInUserAsync(user);

            return RedirectToAction("Index", "Adverts");
        }
        [HttpGet]
        public IActionResult SignUp() => View();
        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserDto user)
        {
            await _userService.CreateUserAsync(user);
            return RedirectToAction("Index", "Adverts");
        }
    }
}
