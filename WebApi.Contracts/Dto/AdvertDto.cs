using Ads.CoreService.Contracts.Dto.Internal.Base;
using System;
using System.Collections.Generic;

namespace Ads.CoreService.Contracts.Dto
{
    public class AdvertDto : Base
    {
        //public string DefaultImage { get; set; }

        /// <summary>
        /// Описание объявления / Ads description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Стопимость / Price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Id cтатуca объявления / Id of a ads status
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Id владельца объявления / Id of a ads owner
        /// Связь будет реализована после добавления MS Identity / 
        /// The relation will be implemented after the MS Identity added
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Контекст объявления для расширения функционала / 
        /// Ads context for a functional extends
        /// </summary>
        public string Context { get; set; }
        /// <summary>
        /// Дата создания / Creation date 
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Id города / City id
        /// </summary>
        public CityDto City { get; set; }
        /// <summary>
        /// Tип объявления / Ads type
        /// </summary>
        public AdvertTypeDto Type { get; set; }
        /// <summary>
        /// Cтатуc объявления / Ads status
        /// </summary>
        public StatusDto Status { get; set; }
        /// <summary>
        /// Категория, в которой находится объявление / 
        /// The category in which that advert contains
        /// </summary>
        public CategoryDto Category { get; set; }
        /// <summary>
        /// Коллекция фотографий объявления / 
        /// Advert photos collection
        /// </summary>
        public virtual IEnumerable<ImageDto> Images { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public AdvertDto()
        {
            Created = DateTime.Now;
        }
    }
}
