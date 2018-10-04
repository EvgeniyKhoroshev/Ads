using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Status : Base.EntityWithTypedIdBase<int>
    {
        /// <summary>
        /// Имя статуса / Name of status
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Один-ко-одному свзязь к объявлениям / One-to-one relation to adverts
        /// </summary> 
        [ForeignKey("Id")]
        public Advert Advert { get; set; }
    }
}
