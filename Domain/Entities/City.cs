using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class City : Base.EntityWithTypedIdBase<int>
    {
        /// <summary>
        /// Id региона / region Id
        /// </summary>
        public int RegionId { get; set; }
        /// <summary>
        /// Название города / City name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Один-ко-одному свзязь к объявлениям / One-to-one relation to adverts
        /// </summary> 
        [ForeignKey("Id")]
        public Advert Advert { get; set; }
        /// <summary>
        /// Один-ко-многим свзязь к регионам / One-to-many relation to regions
        /// </summary> 
        [ForeignKey("RegionId")]
        public Region Region { get; set; }
    }
}
