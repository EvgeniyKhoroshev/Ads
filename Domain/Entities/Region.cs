using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
<<<<<<< HEAD
    public class Region : Base.EntityWithTypedIdBase<int>
=======
    class Region : EntityWithTypedIdBase<int>
>>>>>>> 1f7dbd282b9848143f7fb86c8156b07ff306a7ed
    {
        /// <summary>
        /// Название региона / name of region
        /// </summary>
        public string Name { get; set; }
    }
}
