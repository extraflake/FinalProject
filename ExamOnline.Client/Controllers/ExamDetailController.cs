using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Client.Controllers
{
    public class ExamDetailController : Controller
    {
        public IActionResult Show()
        {
            return View();
        }
    }
}
