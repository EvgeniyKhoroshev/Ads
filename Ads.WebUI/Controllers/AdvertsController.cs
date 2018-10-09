using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ads.WebUI.Models;
using Ads.Contracts.Dto;
using System.Net.Http;
using System;
using AutoMapper;

namespace Ads.WebUI.Controllers
{
    public class AdvertsController : Controller
    {
        async Task advInfoInit()
        {
            if (advertsInfoDto == null)
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:56663/api/info");
                    if (response.IsSuccessStatusCode)
                    {
                        advertsInfoDto = await response.Content.ReadAsAsync<AdvertsInfoDto>();
                    }
                }
            }
        }
        AdvertsInfoDto advertsInfoDto;
        public async Task<IActionResult> Index()
        {
            await advInfoInit();
            List<AdsVMIndex> ret = new List<AdsVMIndex>();
            List<AdvertDto> result = null;
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:56663/api/adverts");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<List<AdvertDto>>();
                }
            }
            AdsVMIndex adsVM;
            foreach (var r in result)
            {
                adsVM = Mapper.Map<AdsVMIndex>(r);
                adsVM.City = advertsInfoDto.FindCityById(r.CityId);
                ret.Add(adsVM);
            }
            return View(ret);
        }
        public async Task<IActionResult> Create()
        {
            await advInfoInit();
            return View(advertsInfoDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(
            [Bind("Name","Description","Address", "Price", "CategoryId", "CityId", "TypeId", "StatusId", "Context")]
                                                AdvertDto advert)
        {
            AdvertDto result = null;
            advert.Created = DateTime.Now;
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync($"http://localhost:56663/api/adverts/create", advert);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<AdvertDto>();
                }
            }
            return Redirect("Index");
        }
        //[HttpPost]
        //public IActionResult Delete()
        //{
        //    int id = (int)ViewData["id"];
            
        //    return View();
        //}

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
