using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    class City
    {
        /// <summary>
        /// Id города / City id
        /// </summary>
        public int Id { get; set; }
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
