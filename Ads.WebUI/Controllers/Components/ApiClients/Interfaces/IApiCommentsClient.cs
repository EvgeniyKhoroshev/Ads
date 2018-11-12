using Ads.Contracts.Dto;
using Ads.MVCClientApplication.Controllers.Components.ApiClients.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ads.MVCClientApplication.Controllers.Components.ApiClients.Interfaces
{
    public interface IApiCommentsClient : IApiBaseClient<CommentDto, int>
    {

    }
}
