using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ads.MVCClientApplication.Models;
using Ads.CoreService.Contracts.Dto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.Interfaces;
using Ads.MVCClientApplication.Controllers.Components;

namespace Ads.MVCClientApplication.Controllers
{
    public class CommentsController : Controller
    {
        readonly IApiAdvertClient _advertClient;
        readonly IApiCommentsClient _commentsClient;
        public CommentsController(IApiAdvertClient advertClient,
                                  IApiCommentsClient commentsClient)
        {
            _advertClient = advertClient;
            _commentsClient = commentsClient;
        }
        [HttpPost]
        public async Task<ActionResult<CommentDto>> SaveOrUpdate([FromBody] CommentDto comment)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();
            comment.UserId = UserProcessing.GetCurrentUserId(HttpContext).Value;
            return Ok(await _commentsClient.SaveOrUpdate(comment));
        }
        [HttpGet("advertcomments/{advertId}")]
        public async Task<IList<CommentDto>> GetAdvertComments(int advertId)
        {
            return await _advertClient.GetAdvertCommentsAsync(advertId);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteComment([FromBody] CommentDto del)
        {
            if (UserProcessing.IsValidCurrentUser(HttpContext, del.UserId))
                return await _commentsClient.Delete(del.Id);
            else return BadRequest();
        }    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
