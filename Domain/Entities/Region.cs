using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    class Region : EntityWithTypedIdBase<int>
    {
        /// <summary>
        /// Название региона / name of region
        /// </summary>
        public string Name { get; set; }
    }
}
