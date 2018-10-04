using Domain.Entities;
using Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// Один-ко-одному свзязь к объявлениям / One-to-one relation to adverts
        /// </summary> 
        [ForeignKey("Id")]
        public Advert Advert { get; set; }
    }
}