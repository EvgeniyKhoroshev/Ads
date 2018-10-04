using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class AdvertType : Base.EntityWithTypedIdBase<int>
    {
        /// <summary>
        /// Название типа / Name of advert type
        /// </summary>
        public string Type { get; set; }
    }
}
