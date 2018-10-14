using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Base
{
    public class BaseEntity : EntityWithTypedIdBase<int>
    {
        /// <summary>
        /// Дата создания / Creation date 
        /// </summary>
        [Required]
        public DateTime Created { get; set; }
        public BaseEntity()
        {
            Created = DateTime.Now;
        }
    }
}
