using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ads.WebUI.Models
{
    public class AdsVMIndex
    {
        public int Id { get; set; }
        /// <summary>
        /// Название объявления / Advert name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Стопимость / Price
        /// </summary>
        public uint Price { get; set; }
        /// <summary>
        /// Id города / City id
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// Дата создания / Creation date 
        /// </summary>
        public DateTime Created { get; set; }
    }
}
