using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ads.WebUI.Models;
using Ads.Contracts.Dto;
using System.Net.Http;

namespace Ads.WebUI.Controllers
{
    public class AdvertsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<AdvertDto> result = null;
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:56663/api/adverts");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<List<AdvertDto>>();
                }
            }
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            AdvertsInfoDto result = null;
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:56663/api/adverts/create");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<AdvertsInfoDto>();
                }
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(
            [Bind("Name","Descrtiption","Address", "Price")] AdvertDto advert)
        {
            AdvertsInfoDto result = null;
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:56663/api/adverts/new");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<AdvertsInfoDto>();
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
