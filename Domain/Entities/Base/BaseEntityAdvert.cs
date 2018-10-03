﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Base
{
    public class BaseEntityAdvert : BaseEntityPost
    {
        /// <summary>
        /// Id категории, в которой находится объявление / 
        /// Id of the category in which that advert contains
        /// </summary>
        [Required]
        public int CategoryId { get; set; }
        /// <summary>
        /// Название объявления / Advert name
        /// </summary>
        [Required]
        public string AdvertName{ get; set; }
        /// <summary>
        /// Тело поста / Post body
        /// </summary>
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
