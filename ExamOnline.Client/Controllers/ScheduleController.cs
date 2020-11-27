using ExamOnline.Client.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExamOnline.Client.Controllers
{
    public class ScheduleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult Choose()
        {
            return View();
        }

        public ActionResult ChooseSchedule(ExamOnline.Models.Schedule schedule)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(schedule);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync("api/schedules").Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };

                    //var jwt = response.Content.ReadAsStringAsync().Result.ToString();
                    //var handler = new JwtSecurityTokenHandler().ReadJwtToken(jwt.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("RoleName")).Value;
                    //var role = handler;
                    //HttpContext.Session.SetString(SessionEmail, role);
                    //return Json(new { result = "Redirect", url = Url.Action("Dashboard", "Accounts") });

                    return Json(response.Content.ReadAsStringAsync().Result.ToString());

                }
                else
                {
                    return Content("GAGAL");
                }
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadSchedules()
        {
            ExamDetailJson schedule = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44301/api/")
            };
            var responseTask = client.GetAsync("schedules");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                schedule = JsonConvert.DeserializeObject<ExamDetailJson>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(schedule);
        }

        [HttpPost]
        public ActionResult AddSchedule(ExamOnline.Models.Schedule schedule)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(schedule);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("api/schedules",contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };

                    //var jwt = response.Content.ReadAsStringAsync().Result.ToString();
                    //var handler = new JwtSecurityTokenHandler().ReadJwtToken(jwt.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("RoleName")).Value;
                    //var role = handler;
                    //HttpContext.Session.SetString(SessionEmail, role);
                    //return Json(new { result = "Redirect", url = Url.Action("Dashboard", "Accounts") });

                    return Json(response.Content.ReadAsStringAsync().Result.ToString());

                }
                else
                {
                    return Content("GAGAL");
                }
            }
        }

        [HttpPost]
        public ActionResult DeleteSchedule(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(Id);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.DeleteAsync("api/schedules/"+Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };

                    //var jwt = response.Content.ReadAsStringAsync().Result.ToString();
                    //var handler = new JwtSecurityTokenHandler().ReadJwtToken(jwt.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("RoleName")).Value;
                    //var role = handler;
                    //HttpContext.Session.SetString(SessionEmail, role);
                    //return Json(new { result = "Redirect", url = Url.Action("Dashboard", "Accounts") });

                    return Json(response.Content.ReadAsStringAsync().Result.ToString());

                }
                else
                {
                    return Content("GAGAL");
                }
            }
        }

        [HttpGet]
        public ActionResult GetById(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(Id);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync("api/schedules/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };

                    //var jwt = response.Content.ReadAsStringAsync().Result.ToString();
                    //var handler = new JwtSecurityTokenHandler().ReadJwtToken(jwt.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("RoleName")).Value;
                    //var role = handler;
                    //HttpContext.Session.SetString(SessionEmail, role);
                    //return Json(new { result = "Redirect", url = Url.Action("Dashboard", "Accounts") });

                    return Json(response.Content.ReadAsStringAsync().Result.ToString());

                }
                else
                {
                    return Content("GAGAL");
                }
            }
        }

        [HttpPut]
        public ActionResult UpdateSchedule(ExamOnline.Models.Schedule schedule)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(schedule);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PutAsync("api/schedules/" +schedule.Id, contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };

                    //var jwt = response.Content.ReadAsStringAsync().Result.ToString();
                    //var handler = new JwtSecurityTokenHandler().ReadJwtToken(jwt.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("RoleName")).Value;
                    //var role = handler;
                    //HttpContext.Session.SetString(SessionEmail, role);
                    //return Json(new { result = "Redirect", url = Url.Action("Dashboard", "Accounts") });

                    return Json(response.Content.ReadAsStringAsync().Result.ToString());

                }
                else
                {
                    return Content("GAGAL");
                }
            }
        }
    }
}
