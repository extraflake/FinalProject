using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ExamOnline.Client.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExamOnline.Client.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            //try
            //{
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(loginVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("/API/Accounts/Get", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    char[] trimChars = { '/', '"' };
                    var token = response.Content.ReadAsStringAsync().Result.ToString().Trim(trimChars);
                    if (token != "Error")
                    {
                        string getAppId = new JwtSecurityTokenHandler().ReadJwtToken(token.Trim(trimChars)).Claims.FirstOrDefault(x => x.Type.Equals("UserID")).Value;

                        HttpContext.Session.SetString("ApplicantId", getAppId);
                        
                        return Json(new { data = getAppId, token = token, url = Url.Action("Choose", "Schedule") });
                    }
                    else
                    {
                        return Json(new { data = "GAGAL" });
                    }
                }
                else
                {
                    return Json(new { data = "GAGAL" });
                }
                //return View();
            }
            //}
            //catch (Exception)
            //{
            //    return Json(new { data = "Account Tidak Terdaftar" });
            //}

        }
    }
}
