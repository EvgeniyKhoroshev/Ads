namespace Authentication.Contracts.JwtAuthentication
{
    /// <summary>
    /// Перечисление пользовательских заявок, передаваемых в JWT.
    /// </summary>
    public static class JwtCustomClaimNames
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public const string UserId = "ads/jwt/user_id";

        /// <summary>
        /// Логин.
        /// </summary>
        public const string UserName = "ads/jwt/username";
    }
}

