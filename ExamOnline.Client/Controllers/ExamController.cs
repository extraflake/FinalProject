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
    public class ExamController : Controller
    {
        public IActionResult PilihUjian()
        {
            DateTime curDate = DateTime.Now;
            DateTime addingDate = curDate;
            List<DateTime> dateTimes = new List<DateTime>();
            List<String> strDate = new List<string>();
            while (addingDate != curDate.AddDays(7))
            {
                addingDate = addingDate.AddDays(1);
                strDate.Add(addingDate.ToString("dd MMM yyyy HH:mm:ss"));
            }
            ViewBag.Schedule = strDate;
            return View();
        }

        [HttpGet]
        public ActionResult LoadSegment(ExamOnline.Models.Segment segment)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(segment);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync("api/segment").Result;
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
        public ActionResult LoadQuestion(ExamVM exam)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(exam);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync("api/question").Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };

                    //var jwt = response.Content.ReadAsStringAsync().Result.ToString();
                    //var handler = new JwtSecurityTokenHandler().ReadJwtToken(jwt.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("RoleName")).Value;
                    //var role = handler;
                    //HttpContext.Session.SetString(SessionEmail, role);
                    //return Json(new { result = "Redirect", url = Url.Action("Dashboard", "Accounts") });

                    return Json(response.Content.ReadAsStringAsync().Result);

                }
                else
                {
                    return Content("GAGAL");
                }
            }
        }

        public ActionResult Ujian()
        {
            return View();
        }

        public ActionResult Waiting()
        {
            return View();
        }
    }
}
