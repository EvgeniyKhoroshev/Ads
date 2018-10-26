using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Advert : Base.BaseEntity
    {
        /// <summary>
        /// Название объявления / Advert name
        /// </summary>
        [Required]
        public string Name{ get; set; }
        /// <summary>
        /// Описание объявления / Ads description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Стопимость / Price
        /// </summary>
        [Required]
        public decimal Price { get; set; }
        /// <summary>
        /// Id cтатуca объявления / Id of a ads status
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Id категории, в которой находится объявление / 
        /// Id of the category in which that advert contains
        /// </summary>
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        /// <summary>
        /// Id cтатуca объявления / Id of a ads status
        /// </summary>
        [Required]
        public int StatusId { get; set; }
        public Status Status { get; set; }
        /// <summary>
        /// Id типа объявления / Id of ads type
        /// </summary>
        [Required]
        public int TypeId { get; set; }
        public AdvertType Type { get; set; }
        /// <summary>
        /// Id города / City id
        /// </summary>
        [Required]
        public int CityId { get; set; }
        public City City { get; set; }
        /// <summary>
        /// Id владельца объявления / Id of a ads owner
        /// Связь будет реализована после добавления MS Identity / 
        /// The relation will be implemented after the MS Identity added
        /// </summary>
        public int? UserId { get; set; }
        public User User { get; set; }
        /// <summary>
        /// Контекст объявления для расширения функционала / 
        /// Ads context for a functional extends
        /// </summary>
        public string Context { get; set; }
        /// <summary>
        /// Коллекция комментариев объявления / 
        /// Advert comments collection
        /// </summary>
        public virtual IEnumerable<Comment> Comments { get; set; }
        /// <summary>
        /// Коллекция фотографий объявления / 
        /// Advert photos collection
        /// </summary>
        public virtual IEnumerable<Image> Images { get; set; }
        public Advert()
        {
        }
    }
}

