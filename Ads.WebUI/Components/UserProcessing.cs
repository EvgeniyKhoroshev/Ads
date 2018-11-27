using Authentication.Contracts.CookieAuthentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ads.MVCClientApplication.Controllers.Components
{
    public static class UserProcessing
    {
        /// <summary>
        /// Проверка соответствия Id пользователя с Id владельца / 
        /// User id and owner id match check
        /// </summary>
        /// <param name="context">Текущий HttpContext /
        /// Current HttpContext</param>
        /// <param name="OwnerId">Id владельца / 
        /// Owner Id</param>
        /// <returns>Возвращает true, если пользователь авторизован и его Id совпадает с Id владельца /
        /// Returns true if the current user is authorized and his Id is equals to OwnerId</returns>
        public static bool IsValidCurrentUser(HttpContext context, int OwnerId)
        {
            int currentUserId = Convert.ToInt32(context.User.Claims.FirstOrDefault(t => t.Type == CookieCustomClaimNames.UserId).Value);
            if ((currentUserId > 0) && (context.User.Identity.IsAuthenticated) && (currentUserId == OwnerId))
                return true;
                return false;
        }
        public static int? GetCurrentUserId(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated)
                return null;
            int UserId = Convert.ToInt32(
                context.User.Claims.FirstOrDefault(t => t.Type == CookieCustomClaimNames.UserId).Value);
            return UserId;
        }
    }
}
