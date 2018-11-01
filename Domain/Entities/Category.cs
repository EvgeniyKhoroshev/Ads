using Ads.Shared.Domain.Abstractions;
using Domain.Entities;
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
        /// Многие-ко-одному свзязь к объявлениям / Many-to-one relation to adverts
        /// </summary> 
        [ForeignKey("Id")]
        public ICollection<Advert> Adverts { get; set; }
    }
}