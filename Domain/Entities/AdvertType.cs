using Ads.Shared.Domain.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class AdvertType : EntityWithTypedIdBase<int>
    {
        /// <summary>
        /// Название типа / Name of advert type
        /// </summary>

        public string Type { get; set; }
        /// <summary>
        /// Многие-ко-одному свзязь к объявлениям / Many-to-one relation to adverts
        /// </summary> 
        [ForeignKey("Id")]
        public ICollection<Advert> Adverts { get; set; }
    }
}
