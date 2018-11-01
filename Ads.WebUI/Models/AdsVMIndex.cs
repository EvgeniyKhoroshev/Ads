using Ads.Contracts.Dto;
using Ads.Contracts.Dto.Internal;
using System;
using System.Collections.Generic;

namespace Ads.WebUI.Models
{
    public class AdsVMIndex
    {
        /// <summary>
        /// Фотография объявления по-умолчанию
        /// </summary>
        public IEnumerable<string> Images { get; set; }
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
