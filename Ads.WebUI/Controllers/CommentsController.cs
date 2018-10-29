using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ads.WebUI.Models;
using Ads.Contracts.Dto;
using Ads.WebUI.Components.ApiRequests;
using System;
using System.Linq;
using Authentication.Contracts.CookieAuthentication;
using Microsoft.AspNetCore.Http;

namespace Ads.WebUI.Controllers
{
    public class CommentsController : Controller
    {
        private int currentUserId;
        readonly APIRequests _requests;
        IHttpContextAccessor _context;
        public CommentsController(APIRequests requests, IHttpContextAccessor context)
        {
            _context = context;
            currentUserId = Convert.ToInt32(
                _context.HttpContext.User.Claims.FirstOrDefault(
                t => t.Type == CookieCustomClaimNames.UserId).Value);
            _requests = requests;
        }
        [HttpPost]
        public async Task<IActionResult> SaveOrUpdate(
            [Bind("Body,AdvertId")]CommentDto c)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("SignIn", "Authentication" );
            c.UserId = currentUserId;
            await _requests.SaveOrUpdate(c);
            return RedirectToAction("Details", new { controller = "Adverts", id= c.AdvertId});

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("SignIn", "Authentication");
            await _requests.DeleteComment(Id.Value);
            return RedirectToAction("Index");
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
