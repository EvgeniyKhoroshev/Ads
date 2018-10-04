using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Region : EntityWithTypedIdBase<int>
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
