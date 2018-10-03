using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Base
{
    class BaseEntityAdvert : BaseEntityPost
    {
        /// <summary>
        /// Id категории, в которой находится объявление / 
        /// Id of the category in which that advert contains
        /// </summary>
        [Required]
        int CategoryId { get; set; }
        /// <summary>
        /// Название объявления / Advert name
        /// </summary>
        [Required]
        public string AdvertName{ get; set; }
        /// <summary>
        /// Тело поста / Post body
        /// </summary>
    }
}
