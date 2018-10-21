using System;
using System.Collections.Generic;
using System.Text;

namespace Ads.Contracts.Dto
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
