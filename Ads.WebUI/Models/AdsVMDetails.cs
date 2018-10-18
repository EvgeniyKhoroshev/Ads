using Ads.Contracts.Dto;
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
        /// Дата создания / Creation date 
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Описание объявления / Ads description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Город  / Город
        /// </summary>
        public City City { get; set; }
        /// <summary>
        /// Tип объявления / Ads type
        /// </summary>
        public AdvertType Type { get; set; }
        /// <summary>
        /// Cтатуc объявления / Ads status
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// Категория, в которой находится объявление / 
        /// The category in which that advert contains
        /// </summary>
        public Category Category { get; set; }
    }
}
