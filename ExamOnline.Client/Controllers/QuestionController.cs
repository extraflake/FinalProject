﻿using ExamOnline.Client.ViewModel;
using Microsoft.AspNetCore.Http;
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
    public class QuestionController : Controller
    {
       /* const string SessionQuestion = "Quest";
        string QuestionResult = "";*/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadQuestion()
        {

            QuestionJson questions = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44301/api/")
            };
            var responseTask = client.GetAsync("questions");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                questions = JsonConvert.DeserializeObject<QuestionJson>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(questions);
        }

        [HttpPost]
        public ActionResult AddQuestion(ExamOnline.ViewModel.QuestionVM question)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(question);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("api/questions/create", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };
                    return Json(response.Content.ReadAsStringAsync().Result.ToString());

                }
                else
                {
                    return Content("GAGAL");
                }
            }
        }

        [HttpPost]
        public ActionResult DeleteQuestion(QuestionVM question)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(question);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("api/questions/delete",contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };
                    return Json(response.Content.ReadAsStringAsync().Result.ToString());
                }
                else
                {
                    return Content("GAGAL");
                }
            }
        }

        [HttpPost]
        public ActionResult GetById(QuestionVM question)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(question);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("api/questions/GetById", contentData).Result;
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
        public ActionResult UpdateQuestion(QuestionVM question)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(question);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PutAsync("api/questions", contentData).Result;
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
