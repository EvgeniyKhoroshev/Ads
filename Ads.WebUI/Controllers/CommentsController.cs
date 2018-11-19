using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ads.MVCClientApplication.Models;
using Ads.CoreService.Contracts.Dto;
using Ads.MVCClientApplication.Components.ApiRequests;
using System;
using System.Linq;
using Authentication.Contracts.CookieAuthentication;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.Interfaces;
using System.Net.Http;
using Ads.MVCClientApplication.Controllers.Components;

namespace Ads.MVCClientApplication.Controllers
{
    public class CommentsController : Controller
    {
        private int currentUserId;
        readonly ApiClient _requests;
        readonly IApiCommentsClient _commentsClient;
        IHttpContextAccessor _context;
        public CommentsController(ApiClient requests,
            IHttpContextAccessor context,
            IApiCommentsClient commentsClient)
        {
            _context = context;
            currentUserId = Convert.ToInt32(
                _context.HttpContext.User.Claims.FirstOrDefault(
                t => t.Type == CookieCustomClaimNames.UserId).Value);
            _requests = requests;
            _commentsClient = commentsClient;
        }
        [HttpPost]
        public async Task<ActionResult<CommentDto>> SaveOrUpdate([FromBody] CommentDto comment)
        {
            //CommentDto comment = new CommentDto(PostBody, Convert.ToInt32(AdvertId));
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();
            comment.UserId = currentUserId;
            return Ok(await _requests.SaveOrUpdate(comment));
        }
        [HttpGet("advertcomments/{advertId}")]
        public async Task<IList<CommentDto>> GetAdvertComments(int advertId)
        {
            return await _requests.GetAdvertComments(advertId);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteComment([FromBody] CommentDto del)
        {
            if (UserProcessing.IsValidCurrentUser(HttpContext, del.UserId))
                return await _commentsClient.Delete(del.Id);
            else return BadRequest();
        }


        //[HttpPost]
        //public async Task<IActionResult> Delete(int? Id)
        //{
        //    if (!User.Identity.IsAuthenticated)
        //        return RedirectToAction("SignIn", "Authentication");
        //    await _requests.DeleteComment(Id.Value);
        //    return RedirectToAction("Index");
        //}
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public struct DeleteDto
        {
            public int CommentId;
            public int OwnerId;
        }
    }
}
