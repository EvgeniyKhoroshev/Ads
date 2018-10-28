using System;

namespace Authentication.Contracts.JwtAuthentication.Options
{
    public class JwtServerAuthenticationOptions : JwtBaseAuthenticationOptions
    {
        public TimeSpan Lifetime { get; set; }
    }
}
