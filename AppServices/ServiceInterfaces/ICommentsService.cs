using Ads.CoreService.Contracts.Dto;
using Ads.CoreService.Contracts.Dto.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.ServiceInterfaces
{
    public interface ICommentsService : Base.IServiceInterfaceBase<CommentDto, int>
    {
        Task<IList<CommentDto>> GetAdvertCommentsAsync(int advertId);
    }
}
