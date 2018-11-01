using Ads.Shared.Domain.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Status : EntityWithTypedIdBase<int>
    {
        /// <summary>
        /// Имя статуса / Name of status
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Многие-ко-одному свзязь к объявлениям / Many-to-one relation to adverts
        /// </summary> 
        [ForeignKey("Id")]
        public ICollection<Advert> Adverts { get; set; }
    }
}
