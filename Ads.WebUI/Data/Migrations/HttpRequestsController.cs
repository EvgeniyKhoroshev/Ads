using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ads.WebUI.Data.Migrations
{
    public class HttpRequestsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}