using Ads.Contracts.Dto;
using Ads.WebUI.Controllers.Components.ApiRequests.BaseRequest;
using Ads.WebUI.Controllers.Components.ApiRequests.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ads.WebUI.Controllers.Components.ApiRequests.AdvertRequests
{
    public class ApiCommentsClient : ApiBaseClient<CommentDto, int>, IApiCommentsClient
    {
        public ApiCommentsClient() : base("comments") { }

    }
}
