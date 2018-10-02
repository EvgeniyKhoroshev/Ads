using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Base
{
    class BaseEntityBoard : BaseEntityPost
    {
        /// <summary>
        /// Название доски / Board name
        /// </summary>
        [Required]
        string BoardName{ get; set; }
        /// <summary>
        /// Тело поста / Post body
        /// </summary>
        
    }
}
