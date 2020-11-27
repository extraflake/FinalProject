using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            try
            {
                using (HttpClient client = new HttpClient())
                {
                //http://haidaraldi-001-site1.htempurl.com
                    client.BaseAddress = new Uri("https://localhost:44358");
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string data = JsonConvert.SerializeObject(registerVM);
                    var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("/API/Accounts/Get", contentData).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        char[] trimChars = { '/', '"' };
                        var token = response.Content.ReadAsStringAsync().Result.ToString().Trim(trimChars);

                        string Application = GetApplication(token);
                        string Username = GetUsername(token);
                        string UserID = GetUserID(token);
                        string Email = GetEmail(token);
                        string EmployeeId = GetEmployeeId(token);
                        

                        HttpContext.Session.SetString("Application", Application);
                        HttpContext.Session.SetString("Username", Username);
                        HttpContext.Session.SetString("UserId", UserID);
                        HttpContext.Session.SetString("Token", token);
                        HttpContext.Session.SetString("Email", Email);
                        HttpContext.Session.SetString("EmployeeId", EmployeeId);
                        try
                        {
                            string EducationId = GetEducationId(token);
                            string UniversityId = GetUniversityId(token);
                            string DepartmentId = GetDepartmentId(token);
                            HttpContext.Session.SetString("EducationId", EducationId);
                            HttpContext.Session.SetString("UniversityId", UniversityId);
                            HttpContext.Session.SetString("DepartmentId", DepartmentId);
                        }
                        catch (Exception)
                        {
                            HttpContext.Session.SetString("EducationId", "");
                            HttpContext.Session.SetString("UniversityId", "");
                            HttpContext.Session.SetString("DepartmentId", "");
                        }
                        if (token.Equals("Error"))
                        {
                            return Json(new { data = "Login Gagal" });
                        }
                        return Json(new { data = "berhasil", token = token, url = Url.Action("Index", "Registration") });
                    }
                    else
                    {
                        return Json(new { data = "Login Gagal" });
                    }
                    //return View();
                }
            }
            catch (Exception)
            {
                return Json(new { data = "Account Tidak Terdaftar" });
            }

        }

        protected string GetEmployeeId(string token)
        {
            char[] trimChars = { '/', '"' };

            var handler = new JwtSecurityTokenHandler().ReadJwtToken(token.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("EmployeeId")).Value;
            return handler;
        }

        protected string GetEducationId(string token)
        {
            char[] trimChars = { '/', '"' };

            var handler = new JwtSecurityTokenHandler().ReadJwtToken(token.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("EducationID")).Value;
            return handler;
        }

        protected string GetUniversityId(string token)
        {
            char[] trimChars = { '/', '"' };

            var handler = new JwtSecurityTokenHandler().ReadJwtToken(token.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("UniversityID")).Value;
            return handler;
        }

        protected string GetDepartmentId(string token)
        {
            char[] trimChars = { '/', '"' };

            var handler = new JwtSecurityTokenHandler().ReadJwtToken(token.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("DepartmentID")).Value;
            return handler;
        }

        protected string GetEmail(string token)
        {
            char[] trimChars = { '/', '"' };

            var handler = new JwtSecurityTokenHandler().ReadJwtToken(token.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("User_Email")).Value;
            return handler;
        }

        protected string GetApplication(string token)
        {
            char[] trimChars = { '/', '"' };

            var handler = new JwtSecurityTokenHandler().ReadJwtToken(token.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("UserApplication")).Value;

            string[] words = handler.Split(',');

            string application = words[0];

            return application;
        }

        protected string GetUsername(string token)
        {
            char[] trimChars = { '/', '"' };

            var handler = new JwtSecurityTokenHandler().ReadJwtToken(token.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("Username")).Value;
            return handler;
        }

        protected string GetUserID(string token)
        {
            char[] trimChars = { '/', '"' };

            var handler = new JwtSecurityTokenHandler().ReadJwtToken(token.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("UserID")).Value;
            return handler;
        }

        //Forgot
        public IActionResult Forgot()
        {
            return View();
        }

        [HttpPatch]
        public ActionResult Forgot(RegisterVM registerVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(registerVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PatchAsync("/API/Accounts", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };
                    if (response.Content.ReadAsStringAsync().Result.ToString().Trim(trimChars).Equals("404"))
                    {
                        return Json(new { data = "Email Invalid" });
                    }
                    return Json(new { data = "berhasil", url = Url.Action("Index", "Account") });
                }
                else
                {
                    return Json(new { data = "Email Tidak Terdaftar" });
                }
                //return View();
            }
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
                                    return Json(new { data = "berhasil", result = "Redirect", url = Url.Action("Index", "Account"), dataBack = response.Content.ReadAsStringAsync().Result.ToString() });
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
                    return "Email Invalid";
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
                    return "Username Invalid";
                }
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
                    return "Phone Invalid";
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

        [HttpPut]
        public ActionResult Change(RegisterVM registerVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://haidaraldi-001-site1.htempurl.com");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                var token = HttpContext.Session.GetString("Token");
                char[] trimChars = { '/', '"' };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim(trimChars));
                registerVM.User_Email = HttpContext.Session.GetString("Email");

                string data = JsonConvert.SerializeObject(registerVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PutAsync("/API/Accounts/ChangePassword", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { data = "berhasil", url = Url.Action("Index", "Registration") });
                }
                else
                {
                    return Json(new { data = "gagal" });
                }
                //return View();
            }
        }

        public IActionResult Update()
        {
            return View();
        }
    }
}
