using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Client_grafik.Controllers
{
    public class GrafikController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
