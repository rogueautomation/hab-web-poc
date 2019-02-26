using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HabitatWeb.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;

namespace HabitatWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _hostingEnv;

        public HomeController(
            IConfiguration config,
            IHostingEnvironment hostingEnv)
        {
            _config = config;
            _hostingEnv = hostingEnv;
        }

        public IActionResult Index()
        {
            var listStocks = new List<Stock>();

            var wwwRoot = _hostingEnv.WebRootPath;

            var dataPath = Path.Combine(wwwRoot, @"data\HabitatWebData.json");

            if (System.IO.File.Exists(dataPath))
            {
                var json = System.IO.File.ReadAllText(dataPath);

                var stocks = JsonConvert.DeserializeObject<List<Stock>>(json);

                if (stocks != null && stocks.Count() > 0)
                {
                    listStocks = stocks;
                }
            }            

            return View(listStocks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
