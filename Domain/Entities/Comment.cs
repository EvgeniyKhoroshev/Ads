using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Comment : Base.BaseEntityPost
    {
        /// <summary>
        /// Id объявления, к которому принадлежит комментарий / 
        /// Id of the advert in which this comment contains
        /// </summary> 
        [Required]
        public int AdvertId { get; set; }
        public Advert Advert { get; set; }
    }
}
