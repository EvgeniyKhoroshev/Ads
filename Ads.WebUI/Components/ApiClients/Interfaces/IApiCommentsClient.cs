﻿using Ads.CoreService.Contracts.Dto;
using Ads.MVCClientApplication.Components.ApiClients.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ads.MVCClientApplication.Components.ApiClients.Interfaces
{
    public interface IApiCommentsClient : IApiBaseClient<CommentDto, int>
    {

    }
}
