using Ads.Contracts.Dto;
using Ads.WebUI.Components.ApiRequests;
using AppServices.ServiceInterfaces;
using Authentication.AppServices.CookieAuthentication;
using Authentication.Contracts.Basic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ads.WebUI.Controllers
{
    public class AuthenticationController : Controller
    {
        IJwtBasedCookieAuthenticationService _service;
        public AuthenticationController(IJwtBasedCookieAuthenticationService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult SignIn() => View();
        [HttpPost]
        public async Task<IActionResult> SignIn(BasicAuthenticationRequest model)
        {
            if (model == null)
                return BadRequest();

            var authenticationResult = await _service.SignInAsync(new BasicAuthenticationRequest
            {
                Password = model.Password,
                Username = model.Username
            });

            if (!authenticationResult.IsSucceed)
                return Unauthorized();

            return RedirectToAction("Index", "Adverts");
            //await APIRequests.SignIn(user);

        }
        [HttpGet]
        public IActionResult SignUp() => View();
        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserDto user)
        {
            await APIRequests.CreateUser(user);
            return RedirectToAction("Index", "Adverts");
        }
    }
}
