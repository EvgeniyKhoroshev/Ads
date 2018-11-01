﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ads.WebUI.Models;
using Ads.Contracts.Dto;
using System;
using AutoMapper;
using Ads.Contracts.Dto.Filters;
using Ads.WebUI.Controllers.Components;
using Microsoft.AspNetCore.Http;
using Ads.WebUI.Components.ApiRequests;
using Authentication.Contracts.CookieAuthentication;
using System.Linq;
using Ads.CoreService.Contracts.Dto.Filters;
using Ads.Shared.Contracts;

namespace Ads.WebUI.Controllers
{
    public class AdvertsController : Controller
    {
        private readonly ApiClient _client;
        public AdvertsController (ApiClient client)
        {
            _client = client;
        }
        AdvertsInfoDto _AdvertsInfoDto;
        public async Task<IActionResult> Index(
            [Bind("CategoryId,RegionId,CityId,Substring,TypeId")] AdvertFilterDto filter,
            decimal? Min, decimal? Max, int PageNumber)
        {
            filter.PriceRange = new InclusiveRange<decimal?> { From = Min, To = Max };
            if (PageNumber > 1)
                filter.PageNumber = PageNumber;
            if (_AdvertsInfoDto == null)
                _AdvertsInfoDto = await ApiClient.AdvInfoInit();
            var adverts = await _client.FiltredAsync(filter);
            return View(adverts);

        }
        [HttpGet("[controller]/{id}/comments")]
        public async Task<IList<CommentDto>> GetAdvertComments(int? id)
        {
            IList<CommentDto> result;
            if (id.HasValue)
                try
                {
                    result = await _client.GetAdvertComments(id.Value);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new ArgumentOutOfRangeException("Не удалось получить комментарии данного " +
                        "объявления id = {id}, возможно такого объявления не существует. " + ex.Message);
                }
            return null;
        }
        [HttpGet("[controller]/{AdvertId}/comments/add")]
        public async Task<CommentDto> AddComment(string Body, int AdvertId)
        {
            CommentDto cDto = new CommentDto(Body, AdvertId);
            await _client.SaveOrUpdate(cDto);
            return cDto;
        }
        public async Task<IActionResult> Create()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("SignIn", "Authentication");
            if (_AdvertsInfoDto == null)
                _AdvertsInfoDto = await ApiClient.AdvInfoInit();
            return View(_AdvertsInfoDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(
            [Bind("Name,Description,Address,Price,Context,CategoryId,CityId,TypeId,StatusId")]AdvertDto advert,
            List<IFormFile> Photos)
        {
            List<ImageDto> s = null;
            int currentUserId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(t => t.Type == CookieCustomClaimNames.UserId).Value);
            if ((currentUserId > 0) && (HttpContext.User.Identity.IsAuthenticated))
            {
                advert.UserId = currentUserId;
                advert.UserId = 1;
                if (Photos.Count > 0)
                    s = await ImageProcessing.ImageToBase64(Photos, advert.Id);
                advert.Images = s;
                await _client.SaveOrUpdate(advert);
                return Redirect("Index");
            }
            RedirectToAction("SignIn", "Authentication");
            return Unauthorized();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? Id, int userId)
        {
            int currentUserId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(t => t.Type == CookieCustomClaimNames.UserId).Value);
            if ((currentUserId > 0) && (HttpContext.User.Identity.IsAuthenticated) && (currentUserId == userId))
                await _client.DeleteAdvert(Id.Value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                if (_AdvertsInfoDto == null)
                    _AdvertsInfoDto = await ApiClient.AdvInfoInit();
                AdvertDto buf = await _client.GetAdvert(id.Value);
                AdsVMDetails result = Mapper.Map<AdsVMDetails>(buf);
                return View(result);
            }
            return View();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var c = GetCurrentUserId();
            if (!c.HasValue)
                return RedirectToAction("SignIn", "Authintication");
            if (_AdvertsInfoDto == null)
                _AdvertsInfoDto = await ApiClient.AdvInfoInit();
            AdvertDto buf = await _client.GetAdvert(id.Value);
            return View(buf);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(
            [Bind("Id,Name,Description,Address,Price,CategoryId,CityId,TypeId,StatusId,Context")]AdvertDto advert, List<IFormFile> Photos)
        {

            List<ImageDto> s = null;
            if (Photos.Count > 0)
                s = await ImageProcessing.ImageToBase64(Photos, advert.Id);
            // Затычка для пользователей.
            advert.Images = s;
            advert.UserId = 1;
            await _client.SaveOrUpdate(advert);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public int? GetCurrentUserId()
        {
            if (!User.Identity.IsAuthenticated)
                return null;
            int UserId = Convert.ToInt32(
                User.Claims.FirstOrDefault(t => t.Type == CookieCustomClaimNames.UserId).Value);
            return UserId;                
        }




    }
}
