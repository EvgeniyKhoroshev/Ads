using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Type : Base.EntityWithTypedIdBase<int>
    {
        /// <summary>
        /// Название типа / Name of advert type
        /// </summary>
        public string AdvertType { get; set; }
    }
}
