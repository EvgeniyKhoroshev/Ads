using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ads.MVCClientApplication.Models;
using Ads.CoreService.Contracts.Dto;
using System;
using AutoMapper;
using Ads.MVCClientApplication.Controllers.Components;
using Microsoft.AspNetCore.Http;
using Ads.MVCClientApplication.Components.ApiRequests;
using Authentication.Contracts.CookieAuthentication;
using System.Linq;
using Ads.CoreService.Contracts.Dto.Filters;
using Ads.Shared.Contracts;

namespace Ads.MVCClientApplication.Controllers
{
    public class AdvertsController : Controller
    {
        private readonly ApiClient _client;
        public AdvertsController(ApiClient client)
        {
            _client = client;
        }
        public async Task<IActionResult> Index(
            [Bind("CategoryId,RegionId,CityId,Substring,TypeId,onlyPhoto,onlyName")] AdvertFilterDto filter,
            decimal? Min, decimal? Max, int PageNumber)
        {
            filter.PriceRange = new InclusiveRange<decimal?> { From = Min, To = Max };
            if (PageNumber > 1)
                filter.PageNumber = PageNumber;
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
        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("SignIn", "Authentication");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(
            [Bind("Name,Description,Address,Price,Context,CategoryId,CityId,TypeId,StatusId")]AdvertDto advert,
            List<IFormFile> Photos)
        {
            int currentUserId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(t => t.Type == CookieCustomClaimNames.UserId).Value);
            if ((currentUserId > 0) && (HttpContext.User.Identity.IsAuthenticated))
            {
                advert.UserId = currentUserId;
                if (Photos.Count > 0)
                    advert.Images = await ImageProcessing.ImageToBase64(Photos, advert.Id);
                await _client.SaveOrUpdate(advert);
                return Redirect("Index");
            }
            RedirectToAction("SignIn", "Authentication");
            return Unauthorized();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? Id, int OwnerId)
        {
            if (UserProcessing.IsValidCurrentUser(HttpContext, OwnerId))
                await _client.DeleteAdvert(Id.Value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                AdvertDto buf = await _client.GetAdvert(id.Value);
                AdsVMDetails result = Mapper.Map<AdsVMDetails>(buf);
                return View(result);
            }
            return View();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var c = UserProcessing.GetCurrentUserId(HttpContext);
            if (!c.HasValue)
                return RedirectToAction("SignIn", "Authentication");
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
            advert.Images = s;
            advert.UserId = UserProcessing.GetCurrentUserId(HttpContext).Value;
            await _client.SaveOrUpdate(advert);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
