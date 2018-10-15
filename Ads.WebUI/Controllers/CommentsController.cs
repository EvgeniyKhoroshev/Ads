using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ads.WebUI.Models;
using Ads.Contracts.Dto;
using System;

namespace Ads.WebUI.Controllers
{
    public class CommentsController : Controller
    {
        [HttpPost]
        public async Task SaveOrUpdate(
            [Bind("Body,AdvertId")]CommentDto c)
        {
            c.Created = DateTime.Now;
            await APIRequests.SaveOrUpdateComment(c);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? Id)
        {
            await APIRequests.DeleteAdvert(Id.Value);
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public async Task<IActionResult> Filter()
        //{
        //    if (_AdvertsInfoDto == null)
        //        _AdvertsInfoDto = await APIRequests.AdvInfoInit();
        //    List<AdsVMIndex> ret = new List<AdsVMIndex>();
        //    AdsVMIndex adsVM;
        //    foreach (var r in await APIRequests.GetAdverts())
        //    {
        //        adsVM = Mapper.Map<AdsVMIndex>(r);
        //        adsVM.City = _AdvertsInfoDto.FindCityById(r.CityId);
        //        ret.Add(adsVM);
        //    }
        //    return View(ret);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Filter(decimal? MinValue, decimal? MaxValue)
        //{
        //    FilterDto f = new FilterDto();
        //    f.PriceRange.MaxValue = MaxValue;
        //    f.PriceRange.MinValue = MinValue;

        //    AdvertDto[] result =  await APIRequests.Filter(f);
        //    if (_AdvertsInfoDto == null)
        //        _AdvertsInfoDto = await APIRequests.AdvInfoInit();
        //    List<AdsVMIndex> ret = new List<AdsVMIndex>();
        //    AdsVMIndex adsVM;
        //    foreach (var r in result)
        //    {
        //        adsVM = Mapper.Map<AdsVMIndex>(r);
        //        adsVM.City = _AdvertsInfoDto.FindCityById(r.CityId);
        //        ret.Add(adsVM);
        //    }
        //    return View(ret);
        //}
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (_AdvertsInfoDto == null)
        //        _AdvertsInfoDto = await APIRequests.AdvInfoInit();
        //    AdvertDto buf = await APIRequests.GetAdvert(id.Value);
        //    return View(buf);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Edit(
        //    [Bind("Name,Description,Address,Price,CategoryId,CityId,TypeId,StatusId,Context")]AdvertDto advert)
        //{
        //    await APIRequests.CreateAdvert(advert);
        //    return RedirectToAction("Index");
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }





        //private List<AdsVMIndex> GetVMIndex(AdvertDto[] source)
        //{
        //    List<AdsVMIndex> ret = new List<AdsVMIndex>();
        //    AdsVMIndex adsVM;
        //    foreach (var r in source)
        //    {
        //        adsVM = Mapper.Map<AdsVMIndex>(r);
        //        adsVM.City = _AdvertsInfoDto.FindCityById(r.CityId);
        //        ret.Add(adsVM);
        //    }
        //    return ret;
        //}
    }
}
