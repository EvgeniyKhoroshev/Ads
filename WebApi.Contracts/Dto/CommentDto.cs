using Ads.Shared.Domain.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ads.Contracts.Dto
{
    public class CommentDto : BaseEntityPost
    {
        // <inheritdoc>
        public new int Id { get; set; }
        /// <summary>
        /// Id объявления, к которому принадлежит комментарий / 
        /// Id of the advert in which this comment contains
        /// </summary> 
        [Required]
        public int AdvertId { get; set; }
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
        /// Конструктор без параметров / Parameterless constructor
        /// </summary>
        public CommentDto()
        {
            Created = DateTime.Now;
            Rating = 0;
        }

    }
}
