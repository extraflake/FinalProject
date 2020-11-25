using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portal.Client.Models;

namespace Portal.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error([Bind(Prefix ="id")] int statusCode = 0)
        {
            switch (statusCode)
            {
                case 404:
                    return Redirect("~/Error/E404");
                case 403:
                    return Redirect("~/Error/E403");
                case 405:
                    return Redirect("~/Error/E405");
                case 400:
                    return Redirect("~/Error/E400");
                default:
                    return Redirect("~/Error/E500");
            }

            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
