using Ads.Contracts.Dto;
using Ads.WebUI.Controllers.Components.ApiRequests.BaseRequest;
using Ads.WebUI.Controllers.Components.ApiRequests.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Ads.WebUI.Controllers.Components.ApiRequests.AdvertRequests
{
    public class CommentRequest : BaseRequest<CommentDto, int>, ICommentRequest
    {
        public CommentRequest() : base("comments") { }
    }
}
