﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class AdvertType : Base.EntityWithTypedIdBase<int>
    {
        /// <summary>
        /// Название типа / Name of advert type
        /// </summary>

        public string Type { get; set; }
        /// <summary>
        /// Один-ко-одному свзязь к объявлениям / One-to-one relation to adverts
        /// </summary> 
        [ForeignKey("Id")]
        public Advert Advert { get; set; }
    }
}
