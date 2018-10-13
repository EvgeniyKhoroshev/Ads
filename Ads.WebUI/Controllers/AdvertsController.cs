using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ads.WebUI.Models;
using Ads.Contracts.Dto;
using System.Net.Http;
using System;
using AutoMapper;
using Ads.Contracts.Dto.Filters;

namespace Ads.WebUI.Controllers
{
    public class AdvertsController : Controller
    {

        AdvertsInfoDto _AdvertsInfoDto;
        public async Task<IActionResult> Index()
        {
            if (_AdvertsInfoDto == null)
                _AdvertsInfoDto = await APIRequests.AdvInfoInit();
            List<AdsVMIndex> ret = new List<AdsVMIndex>();
            AdsVMIndex adsVM;
            foreach (var r in await APIRequests.GetAdverts())
            {
                adsVM = Mapper.Map<AdsVMIndex>(r);
                adsVM.City = _AdvertsInfoDto.FindCityById(r.CityId);
                ret.Add(adsVM);
            }
            return View(ret);
        }
        public async Task<IActionResult> Create()
        {
            if (_AdvertsInfoDto == null)
                _AdvertsInfoDto = await APIRequests.AdvInfoInit();
            return View(_AdvertsInfoDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(
            [Bind("Name,Description,Address,Price,CategoryId,CityId,TypeId,StatusId,Context")]AdvertDto advert)
        {
            advert.Created = DateTime.Now;
            await APIRequests.CreateAdvert(advert);
            return Redirect("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? Id)
        {
            await APIRequests.DeleteAdvert(Id.Value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                if (_AdvertsInfoDto == null)
                    _AdvertsInfoDto = await APIRequests.AdvInfoInit();
                AdvertDto buf = await APIRequests.GetAdvert(id.Value);
                AdsVMDetails result = Mapper.Map<AdsVMDetails>(buf);
                result.Category = _AdvertsInfoDto.FindCategoryById(buf.CategoryId);
                result.City = _AdvertsInfoDto.FindCityById(buf.CityId);
                result.Type = _AdvertsInfoDto.FindTypeById(buf.TypeId);
                result.Status = _AdvertsInfoDto.FindStatusById(buf.StatusId);
                return View(result);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Filter()
        {
            if (_AdvertsInfoDto == null)
                _AdvertsInfoDto = await APIRequests.AdvInfoInit();
            List<AdsVMIndex> ret = new List<AdsVMIndex>();
            AdsVMIndex adsVM;
            foreach (var r in await APIRequests.GetAdverts())
            {
                adsVM = Mapper.Map<AdsVMIndex>(r);
                adsVM.City = _AdvertsInfoDto.FindCityById(r.CityId);
                ret.Add(adsVM);
            }
            return View(ret);
        }
        [HttpPost]
        public async Task<IActionResult> Filter(decimal MinValue, decimal MaxValue)
        {
            FilterDto f = new FilterDto();
            f.PriceRange.MaxValue = MaxValue;
            f.PriceRange.MinValue = MinValue;

            AdvertDto[] result =  await APIRequests.Filter(f);
            if (_AdvertsInfoDto == null)
                _AdvertsInfoDto = await APIRequests.AdvInfoInit();
            List<AdsVMIndex> ret = new List<AdsVMIndex>();
            AdsVMIndex adsVM;
            foreach (var r in result)
            {
                adsVM = Mapper.Map<AdsVMIndex>(r);
                adsVM.City = _AdvertsInfoDto.FindCityById(r.CityId);
                ret.Add(adsVM);
            }
            return View(ret);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
