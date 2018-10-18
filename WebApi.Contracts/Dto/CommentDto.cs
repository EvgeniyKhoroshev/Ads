using System;
using System.ComponentModel.DataAnnotations;

namespace Ads.Contracts.Dto
{
    public class CommentDto 
    {
        /// <summary>
        /// Идентификатор / Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id объявления, к которому принадлежит комментарий / 
        /// Id of the advert in which this comment contains
        /// </summary> 
        [Required]
        public int AdvertId { get; set; }
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
        /// <param name="AdvertID">Id объявления</param> 
        /// <param name="postBody">Тело поста</param> 
        public CommentDto(string postBody, int AdvertID)
        {
            Body = postBody;
            AdvertId = AdvertID;
            Created = DateTime.Now;
            Rating = 0;
        }
        /// <summary>
        /// Дата создания / Creation date 
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Конструктор без параметров / Parameterless constructor
        /// </summary>
        public CommentDto()
        {
            Body = "";
            Created = DateTime.Now;
            Rating = 0;
        }

    }
}
