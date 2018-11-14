using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string Avatar { get; set; }
        public IEnumerable<Advert> Adverts { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public User()
        {
            EmailConfirmed = false;
            PhoneNumberConfirmed = false;
            AccessFailedCount = 5;
        }

    }
}
