using Ads.Contracts.Dto;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.Interfaces;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.BaseClients;
using Authentication.Contracts.Basic;
using Authentication.Contracts.JwtAuthentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Ads.Shared.Contracts;
using Ads.Shared.Contracts.Areas;

namespace Ads.MVCClientApplication.Controllers.Components.ApiClients.Clients
{
    public class ApiUserClient : ApiBaseClient<UserLoginDto, int>, IApiUserClient
    {
        public ApiUserClient(IHttpContextAccessor context,
            IOptions<ApiBaseOption> opt,
            IOptions<ApiUsersArea> users) : base(context, opt, users) { }

    }
}
