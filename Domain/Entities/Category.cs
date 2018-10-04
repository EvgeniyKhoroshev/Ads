using Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Category : EntityWithTypedIdBase<int>
    {
        /// <summary>
        /// Название категории / Name of category
        /// </summary> 
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Id родительской категории / Id of the parent category
        /// </summary> 
        public int? ParentCategoryId { get; set; }
        /// <summary>
        /// Один-ко-многим свзязь к объявлениям / One-to-many relation to adverts
        /// </summary> 
        public virtual ICollection<Domain.Entities.Advert> Adverts { get; set; }
    }
}