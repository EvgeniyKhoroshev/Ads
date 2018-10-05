using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ads.WebUI.Models;
using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
using System.Net.Http;

namespace Ads.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            AdvertDto result = null;
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:56663/api/values/1");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<AdvertDto>();
                    return View(new AdsVMIndex
                    {
                        Id = result.Id,
                        CityId = result.CityId,
                        Created = result.Created,
                        Name = result.Name, 
                        Price = (uint)result.Price
                    });
                }
            }
            return View(result);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

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
