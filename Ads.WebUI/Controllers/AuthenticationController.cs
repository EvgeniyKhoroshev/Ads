﻿using Ads.Contracts.Dto;
using Ads.MVCClientApplication.Controllers.Components;
using Ads.MVCClientApplication.Components.ApiRequests;
using Authentication.AppServices.CookieAuthentication;
using Authentication.Contracts.Basic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ads.MVCClientApplication.Controllers
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
        [HttpGet]
        public IActionResult Manage()
        {
            UserProcessing.GetCurrentUserId(HttpContext);
            return View();
        }
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
            //await ApiClient.SignIn(user);

        }
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await ApiClient.SignOut();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Adverts");
        }
        [HttpGet]
        public IActionResult SignUp() => View();
        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserDto user)
        {
            await ApiClient.CreateUser(user);
            return RedirectToAction("Index", "Adverts");
        }
    }
}
