using Ads.Contracts.Dto;
using Ads.WebUI.Components.ApiRequests;
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
        [HttpGet]
        public IActionResult SignIn() => View();
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto user)
        {

            await APIRequests.SignIn(user);

            return RedirectToAction("Index", "Adverts");
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
