using Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Region : Base.EntityWithTypedIdBase<int>
    {
        /// <summary>
        /// Название региона / name of region
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Один-ко-многим свзязь к городам / One-to-many relation to city
        /// </summary> 
        [ForeignKey("Id")]
        public ICollection<City> Cities { get; set; }
    }
}
