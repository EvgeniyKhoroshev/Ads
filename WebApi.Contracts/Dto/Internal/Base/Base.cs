using Ads.Shared.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ads.CoreService.Contracts.Dto.Internal.Base
{
    public abstract class Base : EntityWithTypedIdBase<int>
    {
        public new int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary> 
        public string Name { get; set; }
    }
}
