using System.Collections.Generic;
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

namespace Ads.WebUI.Controllers
{
    public class AdvertsController : Controller
    {
        readonly APIRequests _requests;
        public AdvertsController (APIRequests requests)
        {
            _requests = requests;
        }
        AdvertsInfoDto _AdvertsInfoDto;
        public async Task<IActionResult> Index(
            int? CategoryId, int? RegionId, decimal? Min, decimal? Max, int? CityId, string Substring, int Page = 1)
        {
            FilterDto filter = new FilterDto();
            filter.PriceRange.MaxValue = Max;
            filter.PriceRange.MinValue = Min;
            filter.RegionId = RegionId;
            filter.CityId = CityId;
            filter.CategoryId = CategoryId;
            if (Page > 0)
                filter.Pagination.PageNumber = Page;
            filter.Substring = Substring;
            if (_AdvertsInfoDto == null)
                _AdvertsInfoDto = await APIRequests.AdvInfoInit();
            var adverts = await _requests.Filter(filter);
            PagedIndexVM result = new PagedIndexVM
            {
                Adverts = Mapper.Map<AdsVMIndex[]>(adverts),
                Page = filter.Pagination
            };
            result.Page.TotalPages = result.Adverts.Length / result.Page.PageSize + 1;
            return View(result);

        }
        [HttpGet("[controller]/{id}/comments")]
        public async Task<IList<CommentDto>> GetAdvertComments(int? id)
        {
            IList<CommentDto> result;
            if (id.HasValue)
                try
                {
                    result = await APIRequests.GetAdvertComments(id.Value);
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
            await _requests.SaveOrUpdate(cDto);
            return cDto;
        }
        public async Task<IActionResult> Create()
        {
            if (_AdvertsInfoDto == null)
                _AdvertsInfoDto = await APIRequests.AdvInfoInit();
            return View(_AdvertsInfoDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(
            [Bind("Name,Description,Address,Price,Context,CategoryId,CityId,TypeId,StatusId")]AdvertDto advert, List<IFormFile> Photos)
        {
            List<ImageDto> s = null;
            if (Photos.Count > 0)
                s = await ImageProcessing.ImageToBase64(Photos, advert.Id);
            advert.Images = s;
            await _requests.SaveOrUpdate(advert);
            return Redirect("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? Id)
        {
            await _requests.DeleteAdvert(Id.Value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                if (_AdvertsInfoDto == null)
                    _AdvertsInfoDto = await APIRequests.AdvInfoInit();
                AdvertDto buf = await _requests.GetAdvert(id.Value);
                AdsVMDetails result = Mapper.Map<AdsVMDetails>(buf);
                return View(result);
            }
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Filter(decimal? MinValue, decimal? MaxValue)
        //{
        //    FilterDto f = new FilterDto();
        //    f.PriceRange.MaxValue = MaxValue;
        //    f.PriceRange.MinValue = MinValue;

        //    AdvertDto[] result = await APIRequests.Filter(f);
        //    if (_AdvertsInfoDto == null)
        //        _AdvertsInfoDto = await APIRequests.AdvInfoInit();
        //    List<AdsVMIndex> ret = new List<AdsVMIndex>();
        //    AdsVMIndex adsVM;
        //    foreach (var r in result)
        //    {
        //        adsVM = Mapper.Map<AdsVMIndex>(r);
        //        ret.Add(adsVM);
        //    }
        //    return View(ret);
        //}
        public async Task<IActionResult> Edit(int? id)
        {
            if (_AdvertsInfoDto == null)
                _AdvertsInfoDto = await APIRequests.AdvInfoInit();
            AdvertDto buf = await _requests.GetAdvert(id.Value);
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
            await _requests.SaveOrUpdate(advert);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }






    }
}
