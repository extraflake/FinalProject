using ExamOnline.Models;
using ExamOnline.ViewModel;
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
    public class DurationController : Controller
    {
        [HttpPost]
        public IActionResult CreateDuration(Duration duration)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44301/")
            };
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            string data = JsonConvert.SerializeObject(duration);
            var contentData = new StringContent(data, Encoding.UTF8, "application/json");
            var response = client.PostAsync("api/durations", contentData).Result;
            if (response.IsSuccessStatusCode)
            {
                return Json(response.Content.ReadAsStringAsync().Result);

            }
            else
            {
                return Content("GAGAL");
            }
        }

        [HttpPut]
        public ActionResult UpdateDuration(ExamDetailVM examDetailVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(examDetailVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PutAsync("api/durations/updateend", contentData).Result;
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
    }
}
