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
        //Login
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(RegisterVM registerVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(registerVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("/API/Accounts/Get", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };
                    return Json(new { data = "berhasil", token = response.Content.ReadAsStringAsync().Result.ToString().Trim(trimChars) });
                }
                else
                {
                    return Json(new { data = "gagal" });
                }
                //return View();
            }
        }

        public IActionResult Forgot()
        {
            return View();
        }

        //Register
        [HttpPost]
        public ActionResult Register(RegisterVM registerVM)
        {
            string email = CheckEmail(registerVM);
            if (email.Equals("berhasil"))
            {
                string username = CheckUsername(registerVM);
                {
                    if (username.Equals("berhasil"))
                    {
                        string phone = CheckPhone(registerVM);
                        if (phone.Equals("berhasil"))
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
                                    return Json(new { data = "berhasil", result = "Redirect", url = Url.Action("Index", "Account") });
                                }
                                else
                                {
                                    return Json(new { data = "Registrasi gagal! Silahkan coba beberapa saat lagi" });
                                }
                            }
                        }
                        else return Json(new { data = "No HP sudah digunakan" });
                    }
                    else return Json(new { data = "Username sudah digunakan" });
                } 
            }
            else return Json(new { data = "Email sudah digunakan" });
        }

        //Cek Email
        [HttpPost]
        public string CheckEmail(RegisterVM registerVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(registerVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("/API/Accounts/CheckEmail", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };
                    if (response.Content.ReadAsStringAsync().Result.ToString().Trim(trimChars).Equals("Email bisa digunakan"))
                    {
                        return "berhasil";
                    }
                    else return "gagal";
                }
                else
                {
                    return "gagal";
                }
                //return View();
            }
        }

        //Cek Username
        [HttpPost]
        public string CheckUsername(RegisterVM registerVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(registerVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("/API/Accounts/CheckUsername", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };
                    if (response.Content.ReadAsStringAsync().Result.ToString().Trim(trimChars).Equals("Username bisa digunakan"))
                    {
                        return "berhasil";
                    }
                    else return "gagal";
                }
                else
                {
                    return "gagal";
                }
                //return View();
            }
        }

        //Cek Phone
        [HttpPost]
        public string CheckPhone(RegisterVM registerVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(registerVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("/API/Accounts/CheckPhone", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };
                    if (response.Content.ReadAsStringAsync().Result.ToString().Trim(trimChars).Equals("No HP bisa digunakan"))
                    {
                        return "berhasil";
                    }
                    else return "gagal";
                }
                else
                {
                    return "gagal";
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
