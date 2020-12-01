using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Client.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult E404()
        {
            return View();
        }

        public IActionResult E403()
        {
            return View();
        }

        public IActionResult E400()
        {
            return View();
        }

        public IActionResult E405()
        {
            return View();
        }

        public IActionResult E500()
        {
            return View();
        }
    }
}
