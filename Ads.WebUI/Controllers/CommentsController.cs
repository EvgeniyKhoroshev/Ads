using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ads.WebUI.Models;
using Ads.Contracts.Dto;
using Ads.WebUI.Components.ApiRequests;

namespace Ads.WebUI.Controllers
{
    public class CommentsController : Controller
    {
        readonly APIRequests _requests;
        public CommentsController(APIRequests requests)
        {
            _requests = requests;
        }
        [HttpPost]
        public async Task<IActionResult> SaveOrUpdate(
            [Bind("Body,AdvertId")]CommentDto c)
        {
            await _requests.SaveOrUpdate(c);
            return RedirectToAction("Details?id=${c.AdvertId}" ,"Adverts", c.AdvertId);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? Id)
        {
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
