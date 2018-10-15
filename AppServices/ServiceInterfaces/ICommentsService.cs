using Ads.Contracts.Dto;
using Ads.Contracts.Dto.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppServices.ServiceInterfaces
{
    public interface ICommentsService : Base.IServiceInterfaceBase<CommentDto, int>
    {
    }
}
