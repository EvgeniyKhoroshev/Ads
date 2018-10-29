using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Image : Entities.Base.EntityWithTypedIdBase<int>
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int AdvertId { get; set; }
        public Advert Advert { get; set; }
    }
}
