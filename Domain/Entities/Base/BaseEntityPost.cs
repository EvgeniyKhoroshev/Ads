using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Base
{
    public class BaseEntityPost : BaseEntity
    {
        /// <summary>
        /// Тело поста / Post body
        /// </summary>
        [Required]
        [StringLength(500)]
        public string Body { get; set; }
        /// <summary>
        /// Рейтинг / Post rating
        /// </summary>
        [Required]
        public int Rating { get; set; }
        /// <summary>
        /// Id владельца / Owner id
        /// </summary> 
        [Required]
        public int UserId { get; set; }                      
        /// <summary>
        /// Конструктор c телом и Id владельца поста. / Class constructor with a body and id of a post
        /// </summary>
        /// <param name="ownerID">Id владельца</param> 
        /// <param name="postBody">Тело поста</param> 
        public BaseEntityPost(string postBody, int ownerID)
        {
            Body = postBody;
            UserId = ownerID;
            Created = DateTime.Now;
            Rating = 0;
        }
        /// <summary>
        /// Конструктор без параметров / Parameterless constructor
        /// </summary>
        public BaseEntityPost()
        {
            Body = "";
            Created = DateTime.Now;
            Rating = 0;
        }

    }
}
