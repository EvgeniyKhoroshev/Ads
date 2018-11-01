using Ads.Contracts.Dto;
using Ads.WebUI.Controllers.Components.ApiClients.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ads.WebUI.Controllers.Components.ApiClients.Interfaces
{
    public interface IApiCommentsClient : IApiBaseClient<CommentDto, int>
    {

    }
}
