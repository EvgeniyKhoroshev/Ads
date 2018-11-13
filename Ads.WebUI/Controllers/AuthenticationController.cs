using Ads.Contracts.Dto;
using Ads.MVCClientApplication.Controllers.Components;
using Ads.MVCClientApplication.Components.ApiRequests;
using Authentication.AppServices.CookieAuthentication;
using Authentication.Contracts.Basic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ads.MVCClientApplication.Models;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.Interfaces;

namespace Ads.MVCClientApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        IJwtBasedCookieAuthenticationService _service;
        IApiUserClient _apiUserClient;
        public AuthenticationController(IJwtBasedCookieAuthenticationService service,
            IApiUserClient apiUserClient)
        {
            _apiUserClient = apiUserClient;
            _service = service;
        }
        [HttpGet]
        public IActionResult SignIn() => View();
        //[HttpGet]
        //public async Task<IActionResult> Manage()
        //{
        //    var adv = await GetCurrentUserAdverts();
        //    ManageVM vm = new ManageVM
        //    {
        //        Adverts = adv.Value,
        //        Avatar = GetCurrentUserAvatar(),


        //    }
        //    UserProcessing.GetCurrentUserId(HttpContext);
        //    return View();
        //}
        [HttpGet("GetCurrentUserAdverts")]
        public async Task<ActionResult<AdsVMIndex[]>> GetCurrentUserAdverts()
        {
            var userId = UserProcessing.GetCurrentUserId(HttpContext);
            if (userId.HasValue)
                return await _apiUserClient.GetUserAdvertsAsync(userId.Value);
            return null;
        }
        
        [HttpPost]
        public async Task<IActionResult> SignIn(BasicAuthenticationRequest model)
        {
            if (model == null)
                return BadRequest();

            var authenticationResult = await _service.SignInAsync(model);

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
            await _service.SignUpAsync(user);
            return RedirectToAction("Index", "Adverts");
        }
    }
}
