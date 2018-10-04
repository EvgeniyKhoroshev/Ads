using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class City : EntityWithTypedIdBase<int>
    {
        /// <summary>
        /// Id региона / region Id
        /// </summary>
        public int RegionId { get; set; }
        /// <summary>
        /// Название города / City name
        /// </summary>
        public string Name { get; set; }
    }
}
