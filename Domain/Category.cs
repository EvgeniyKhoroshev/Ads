using Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Category : BaseEntity
    {
        /// <summary>
        /// Название категории / Name of category
        /// </summary> 
        [Required]
        public string CategoryName { get; set; }
        /// <summary>
        /// Id родительской категории / Id of the parent category
        /// </summary> 
        public int? ParentCategoryId { get; set; }


        public virtual ICollection<BaseEntityAdvert> BaseEntityAdverts { get; set; }
    }
}
