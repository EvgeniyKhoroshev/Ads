using Ads.Contracts.Dto;
using Ads.WebUI.Controllers.Components.ApiClients.BaseRequest;
using Ads.WebUI.Controllers.Components.ApiClients.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ads.WebUI.Controllers.Components.ApiClients.AdvertRequests
{
    public class ApiCommentsClient : ApiBaseClient<CommentDto, int>, IApiCommentsClient
    {
        public ApiCommentsClient(IHttpContextAccessor context) : base("comments", context) { }

    }
}
