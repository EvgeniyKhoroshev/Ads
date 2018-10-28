namespace Authentication.Contracts.JwtAuthentication.Options
{
    public class JwtClientAuthenticationOptions : JwtBaseAuthenticationOptions
    {
        public string AuthenticationEndpoint { get; set; }
    }
}
