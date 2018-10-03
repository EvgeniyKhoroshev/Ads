using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Base
{
    public class BaseEntityPost : BaseEntity
    {
        /// <summary>
        /// Тело поста / Post body
        /// </summary>
        [Required]
        [StringLength(500)]
        public string PostBody { get; set; }
        /// <summary>
        /// Дата публикации / Date of publishing 
        /// </summary>
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }
        /// <summary>
        /// Рейтинг / Post rating
        /// </summary>
        [Required]
        public int PostRating { get; set; }
        /// <summary>
        /// Id владельца / Owner id
        /// </summary> 
        [Required]
        public int PostOwnerId { get; set; }                      
        /// <summary>
        /// Конструктор c телом и Id владельца поста. / Class constructor with a body and id of a post
        /// </summary>
        /// <param name="ownerID">Id владельца</param> 
        /// <param name="postBody">Тело поста</param> 
        public BaseEntityPost(string postBody, int ownerID)
        {
            PostBody = postBody;
            PostOwnerId = ownerID;
            Created = DateTime.Now;
            PostRating = 0;
        }
        /// <summary>
        /// Конструктор без параметров / Parameterless constructor
        /// </summary>
        public BaseEntityPost()
        {
            PostBody = "";
            Created = DateTime.Now;
            PostRating = 0;
        }

    }
}
