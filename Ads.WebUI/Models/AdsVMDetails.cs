﻿using Ads.CoreService.Contracts.Dto;
using System;
using System.Collections.Generic;

namespace Ads.MVCClientApplication.Models
{
    public class AdsVMDetails
    {
        public int Id { get; set; }
        /// <summary>
        /// Название объявления / Advert name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Стопимость / Price
        /// </summary>
        public uint Price { get; set; }
        /// <summary>
        /// Дата создания / Creation date 
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Описание объявления / Ads description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Город  / Город
        /// </summary>
        public string Address { get; set; }
        //public CityDto City { get; set; }
        /// <summary>
        /// Tип объявления / Ads type
        /// </summary>
        public AdvertTypeDto Type { get; set; }
        /// <summary>
        /// Cтатуc объявления / Ads status
        /// </summary>
        public StatusDto Status { get; set; }
        /// <summary>
        /// Категория, в которой находится объявление / 
        /// The category in which that advert contains
        /// </summary>
        public CategoryDto Category { get; set; }
        public virtual IEnumerable<ImageDto> Images { get; set; }
        /// <summary>
        /// Id владельца объявления / Id of a ads owner
        /// Связь будет реализована после добавления MS Identity / 
        /// The relation will be implemented after the MS Identity added
        /// </summary>
        public int UserId { get; set; }

    }
}
