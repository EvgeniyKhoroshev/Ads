﻿using Ads.CoreService.Contracts.Dto;
using AppServices.ServiceInterfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public class UserService : IUserService
    {
        UserManager<User> _userManager;
        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        public async Task CreateUserAsync(CreateUserDto user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            User entityUser = Mapper.Map<User>(user);

            var result = await _userManager.CreateAsync(entityUser, user.Password);

            if (!result.Succeeded)
                throw new InvalidOperationException(string.Join(Environment.NewLine, result.Errors));
        }
        public async Task<UserInfoDto> GetUserInfoAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return Mapper.Map<UserInfoDto>(user);
        }
    }
}
