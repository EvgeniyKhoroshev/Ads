using Ads.Contracts.Dto.Internal.Base;
using System;

namespace Ads.Contracts.Dto
{
    public class AdvertDto : Base
    {
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
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
    }
}
