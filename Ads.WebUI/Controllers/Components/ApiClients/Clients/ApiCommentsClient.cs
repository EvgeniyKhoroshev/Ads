using Ads.Contracts.Dto;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.BaseClients;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.Interfaces;
using Ads.Shared.Contracts;
using Ads.Shared.Contracts.Areas;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ads.MVCClientApplication.Controllers.Components.ApiClients.AdvertRequests
{
    public class ApiCommentsClient : ApiBaseClient<CommentDto, int>, IApiCommentsClient
    {
        public ApiCommentsClient(IHttpContextAccessor context,
            IOptions<ApiBaseOption> opt,
            IOptions<ApiCommentsArea> comm) : base(context, opt, comm) { }

    }
}
