using Ads.CoreService.Contracts.Dto;
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
using Microsoft.AspNetCore.Http;

namespace Ads.MVCClientApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        IJwtBasedCookieAuthenticationService _jwtBasedCookieAuthenticationService;
        IApiUserClient _apiUserClient;
        public AuthenticationController(IJwtBasedCookieAuthenticationService service,
            IApiUserClient apiUserClient)
        {
            _apiUserClient = apiUserClient;
            _jwtBasedCookieAuthenticationService = service;
        }
        [HttpGet]
        public IActionResult SignIn() => View();
        [HttpGet]
        public async Task<ActionResult<ManageVM>> Manage()
        {
            int userId = UserProcessing.GetCurrentUserId(HttpContext).Value;
            return View(await _apiUserClient.GetUserInfoAsync(userId));
        }
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

            var authenticationResult = await _jwtBasedCookieAuthenticationService.SignInAsync(model);

            if (!authenticationResult.IsSucceed)
                return Unauthorized();

            return RedirectToAction("Index", "Adverts");

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
        public async Task ChangeAvatar(IFormFile Avatar)
        {
            UserAvatarDto a = new UserAvatarDto();
            a.UserId = UserProcessing.GetCurrentUserId(HttpContext).Value;
            a.Avatar = (await ImageProcessing.ImageToBase64(
                new System.Collections.Generic.List<IFormFile> { Avatar }, a.UserId))[0].Content;
            await _apiUserClient.ChangeAvatarAsync(a);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserDto user)
        {
            await _jwtBasedCookieAuthenticationService.SignUpAsync(user);
            return RedirectToAction("Index", "Adverts");
        }
    }
}
