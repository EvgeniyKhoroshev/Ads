using Ads.CoreService.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.ServiceInterfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateUserDto user);

        /// <summary>
        /// Получение информации о пользователе по Id;
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Возвращает информацию о пользователе</returns>
        Task<UserInfoDto> GetUserInfoAsync(int userId);
    }
}
