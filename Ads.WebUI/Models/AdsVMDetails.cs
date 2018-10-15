using System;

namespace Ads.WebUI.Models
{
    public class AdsVMDetails
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
        public string City { get; set; }
        /// <summary>
        /// Дата создания / Creation date 
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Описание объявления / Ads description
        /// </summary>
        public string Description { get; set; }

        public string Type { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
    }
}
