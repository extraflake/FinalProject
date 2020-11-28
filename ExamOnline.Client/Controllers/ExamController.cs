using ExamOnline.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExamOnline.Client.Controllers
{
    public class ExamController : Controller
    {
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
                var response = client.GetAsync("api/segments").Result;
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
        public ActionResult LoadQuestion(QuestionVM question)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                string data = JsonConvert.SerializeObject(question);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("api/questions/getrandom",contentData).Result;
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
        public ActionResult CalculatePoint(ExamDetailVM examDetailVM, IFormFile file)
        {
            examDetailVM.ApplicantId =  Convert.ToInt32(HttpContext.Session.GetString("ApplicantId"));

            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                //examDetailVM.VideoRecord = target.ToArray();
            }

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(examDetailVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PutAsync("api/examdetails", contentData).Result;
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

        public ActionResult Ujian()
        {
            return View();
        }

        public ActionResult Waiting()
        {
            return View();
        }

        public ActionResult StartSegment()
        {
            return View();
        }
    }
}
