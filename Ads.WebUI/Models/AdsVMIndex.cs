using Ads.Contracts.Dto;
using System;

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
        public City City { get; set; }
        /// <summary>
        /// Дата создания / Creation date 
        /// </summary>
        public DateTime Created { get; set; }
    }
}
