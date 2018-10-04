using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public double Price { get; set; }
        /// <summary>
        /// Id родительской категории / Id of a parent category
        /// </summary>
        public int ParentCategoryId { get; set; }
        /// <summary>
        /// Id владельца объявления / Id of a ads owner
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Id города / City id
        /// </summary>
        [Required]
        public int CityId { get; set; }
        /// <summary>
        /// Id типа объявления / Id of ads type
        /// </summary>
        [Required]
        public int TypeId { get; set; }
        /// <summary>
        /// Id cтатуca объявления / Id of a ads status
        /// </summary>
        [Required]
        public int StatusId { get; set; }
        /// <summary>
        /// Id cтатуca объявления / Id of a ads status
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Id категории, в которой находится объявление / 
        /// Id of the category in which that advert contains
        /// </summary>
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
