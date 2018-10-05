using System;

namespace Ads.Contracts.Dto
{
    public class AdvertDto
    {
        public int Id { get; set; }
        /// <summary>
        /// Название объявления / Advert name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание объявления / Ads description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Стопимость / Price
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Id cтатуca объявления / Id of a ads status
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Id категории, в которой находится объявление / 
        /// Id of the category in which that advert contains
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Id cтатуca объявления / Id of a ads status
        /// </summary>
        public int StatusId { get; set; }
        /// <summary>
        /// Id типа объявления / Id of ads type
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// Id города / City id
        /// </summary>
        public int CityId { get; set; }
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
    }
}
