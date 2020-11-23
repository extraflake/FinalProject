using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portal.Client.ViewModels;
using UserManagement.Microservices.Models;

namespace Portal.Client.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult GetNameReligion(Religion religion)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(religion);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync("/api/religions").Result;
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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Forgot()
        {
            return View();
        }

        //Register
        [HttpPost]
        public ActionResult Register(RegisterVM registerVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(registerVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("/API/Accounts/RegisterBC", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { data = "berhasil" });
                }
                else
                {
                    return Json(new { data = "gagal" });
                }
                //return View();
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Change()
        {
            return View();
        }
    }
}
