﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portal.Client.ViewModels;
using Portal.Models;

namespace Portal.Client.Controllers
{
    public class AdminController : Controller
    {
        ////-Referensi-//
        [HttpGet]
        public JsonResult GetReference()
        {
            ReferanceJson referance = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44307")
            };
            var responseTask = client.GetAsync("/api/References");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                referance = JsonConvert.DeserializeObject<ReferanceJson>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(referance);
        }

     
        [HttpPost]
        public ActionResult AddReference(Portal.Models.Reference reference)
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
                    return Json(response.Content.ReadAsStringAsync().Result.ToString());
                }
                else
                {
                    return Content("GAGAL");
                }

            }
        }

        [HttpPut]
        public ActionResult UpdateReference(Portal.Models.Reference reference)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(reference);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PutAsync("/api/references/" + reference.Id, contentData).Result;
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


        [HttpDelete]
        public ActionResult DeleteReference(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(Id);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.DeleteAsync("/api/references/" + Id).Result;
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

        [HttpGet]
        public ActionResult GetByIdReference(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(Id);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync("/api/references/" + Id).Result;
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


        //-Position-//
        [HttpGet]
        public JsonResult GetPosition()
        {
            PositionJson position = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44307")
            };
            var responseTask = client.GetAsync("/api/Positions");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                position = JsonConvert.DeserializeObject<PositionJson>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(position);
        }
        [HttpPost]
        public ActionResult AddPosition(Portal.Models.Position position)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(position);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("/api/positions", contentData).Result;
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

        [HttpPut]
        public ActionResult UpdatePosition(Portal.Models.Position position)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(position);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PutAsync("/api/positions/" + position.Id, contentData).Result;
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


        [HttpDelete]
        public ActionResult DeletePosition(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(Id);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.DeleteAsync("/api/positions/" + Id).Result;
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

        [HttpGet]
        public ActionResult GetByIdPosition(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(Id);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync("/api/positions/" + Id).Result;
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
        public IActionResult Position()
        {
            return View();
        }


        //-Skill-//
        [HttpGet]
        public JsonResult GetSkill()
        {
            SkillJson skill = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44307")
            };
            var responseTask = client.GetAsync("/api/Skills");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                skill = JsonConvert.DeserializeObject<SkillJson>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(skill);
        }
        [HttpPost]
        public ActionResult AddSkill(Portal.Models.Skill skill)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(skill);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("/api/skills", contentData).Result;
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

        [HttpPut]
        public ActionResult UpdateSkill(Portal.Models.Skill skill)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(skill);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PutAsync("/api/skills/" + skill.Id, contentData).Result;
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


        [HttpDelete]
        public ActionResult DeleteSkill(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(Id);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.DeleteAsync("/api/skills/" + Id).Result;
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

        [HttpGet]
        public ActionResult GetByIdSkill(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(Id);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync("/api/skills/" + Id).Result;
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
        public IActionResult Skill()
        {
            return View();
        }


        //--Admin Check--//
        [HttpGet]
        public JsonResult GetApplicant()
        {
            ApplicantJson applicant = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44307")
            };
            var responseTask = client.GetAsync("/api/Applicants/getapplicant");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                applicant = JsonConvert.DeserializeObject<ApplicantJson>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(applicant);
        }

        [HttpPut]
        public ActionResult UpdateCheck(ApplicantVM applicantVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(applicantVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PutAsync("/api/applicants/SetFalse", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { data = "sukses"});
                }
                else
                {
                    return Json(new { data = "gagal"});
                }

            }
        }
        public IActionResult AdminCheck()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetEmployeeData(EditProfileVM editProfileVM)
        {
            using (HttpClient client = new HttpClient())
            {   
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                //string data = JsonConvert.SerializeObject(position);
                //var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync($"/api/employees/{editProfileVM.EmployeeId}").Result;
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
    }
}
