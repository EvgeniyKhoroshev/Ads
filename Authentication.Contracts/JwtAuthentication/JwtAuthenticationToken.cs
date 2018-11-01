using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Contracts.JwtAuthentication
{
    public class JwtAuthenticationToken
    {
        public string AuthToken { get; set; }
        public DateTime? Expires { get; set; }
        public int UserId { get; set; }
    }
}
