using Ads.CoreService.Contracts.Dto;
using Ads.CoreService.Contracts.Dto.Internal;
using System;
using System.Collections.Generic;

namespace Ads.MVCClientApplication.Models
{
    public class AdsVMIndex
    {
        public int Id { get; set; }
        /// <summary>
        /// Фотографии объявления
        /// </summary>
        public virtual IEnumerable<ImageDto> Images { get; set; }
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
        public CityDto City { get; set; }
        /// <summary>
        /// Дата создания / Creation date 
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Информация для пагинации/ Pagination info
        /// </summary>
        public Page Page { get; set; }
        /// <summary>
        /// Id владельца объявления / Id of a ads owner
        /// Связь будет реализована после добавления MS Identity / 
        /// The relation will be implemented after the MS Identity added
        /// </summary>
        public int UserId { get; set; }
    }
}
