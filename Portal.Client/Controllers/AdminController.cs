using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Portal.Client.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Get(Portal.Models.Reference reference)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(reference);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync("/api/references").Result;
                //ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(response.Content.ReadAsStringAsync().Result.ToString());
                }
                else
                {
                    return Content("GAGAL");
                }
            }
        }
        [HttpPost]
        public ActionResult Add(Portal.Models.Reference reference)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(reference);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("/api/references", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new {statusCode = response.StatusCode});
                }
                else
                {
                    return Content("GAGAL");
                }

            }
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Position()
        {
            return View();
        }

        public IActionResult Skill()
        {
            return View();
        }
    }
}
