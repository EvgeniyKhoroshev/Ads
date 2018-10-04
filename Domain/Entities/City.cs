using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// Многие-ко-одному свзязь к объявлениям / Many-to-one relation to adverts
        /// </summary> 
        [ForeignKey("Id")]
        public ICollection<Advert> Adverts { get; set; }
        /// <summary>
        /// Один-ко-многим свзязь к регионам / One-to-many relation to regions
        /// </summary> 
        [ForeignKey("RegionId")]
        public Region Region { get; set; }
    }
}
