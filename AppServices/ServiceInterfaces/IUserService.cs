using Ads.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.ServiceInterfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateUserDto user);
    }
}
