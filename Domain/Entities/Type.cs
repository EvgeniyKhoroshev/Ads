using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    class Type : EntityWithTypedIdBase<int>
    {
        /// <summary>
        /// Название типа / Name of advert type
        /// </summary>
        public string AdvertType { get; set; }
    }
}
