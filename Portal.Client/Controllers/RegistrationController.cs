using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portal.Client.ViewModels;

namespace Portal.Client.Controllers
{
    public class RegistrationController : Controller
    {

        private readonly IWebHostEnvironment _hostEnvironment;

        public RegistrationController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        // Dropdown
        // Update Position DropDown
        [HttpGet]
        public ActionResult GetNamePosition(Portal.Models.Position position)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(position);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync("/api/positions").Result;
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
        //Update Reference Dropdown
        [HttpGet]
        public ActionResult GetNameReference(Portal.Models.Reference reference)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(reference);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync("/api/references").Result;
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
        //Update Skill Dropdown
        [HttpGet]
        public ActionResult GetNameSkill(Portal.Models.Skill skill)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(skill);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync("/api/skills").Result;
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

        // Update Data
        //Update Skill Dropdown
        [HttpGet]
        public ActionResult GetNameUniversity()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                var response = client.GetAsync("/api/universitys").Result;
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

        [HttpGet]
        public ActionResult GetNameDepartment()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                var response = client.GetAsync("/api/departments").Result;
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

        [HttpGet]
        public ActionResult GetDepartment(EditProfileVM editProfileVM)
        {
            try
            {
                editProfileVM.DepartmentId = HttpContext.Session.GetString("DepartmentId");
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44358");
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    var response = client.GetAsync($"/api/departments/{editProfileVM.DepartmentId}").Result;
                    //ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return Json(new { data = response.Content.ReadAsStringAsync().Result.ToString() });
                    }
                    else
                    {
                        return Json(new { data = "gagal" });
                    }
                }
            }
            catch (Exception)
            {
                return Json(new { data = "gagal" });
            }
            //HttpContext.Session.GetString("University");

        }

        [HttpGet]
        public ActionResult GetUniversity(EditProfileVM editProfileVM)
        {
            try
            {
                editProfileVM.UniversityId = HttpContext.Session.GetString("UniversityId");

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44358");
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    var response = client.GetAsync($"/api/universitys/{editProfileVM.UniversityId}").Result;
                    //ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return Json(new { data = response.Content.ReadAsStringAsync().Result.ToString() });
                    }
                    else
                    {
                        return Json(new { data = "gagal" });
                    }
                }
            }
            catch (Exception)
            {
                return Json(new { data = "gagal" });
            }
            //HttpContext.Session.GetString("University");

        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Account/Index");
        }


        //Registration Page
        public IActionResult Index()
        {
            try
            {
                if (HttpContext.Session.GetString("Application").Equals("Portal"))
                {
                    return View();
                }
                else if (HttpContext.Session.GetString("Application").Equals("AdminPortal"))
                {
                    return Redirect("~/Admin/Index");
                }
                else return Redirect("~/Account/Index");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // Registration Page
        // Update Position DropDown

        [HttpGet]
        public ActionResult GetUserData()
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                //string data = JsonConvert.SerializeObject(position);
                //var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync($"/api/users/{UserId}").Result;
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

        [HttpGet]
        public ActionResult GetReligion(RegisterVM registerVM)
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                //string data = JsonConvert.SerializeObject(position);
                //var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync($"/api/religions/{registerVM.ReligionID}").Result;
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

        [HttpGet]
        public ActionResult GetEmployeeData()
        {
            int EmployeeId = Convert.ToInt32(HttpContext.Session.GetString("EmployeeId"));
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                //string data = JsonConvert.SerializeObject(position);
                //var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.GetAsync($"/api/employees/{EmployeeId}").Result;
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

        [HttpGet]
        public ActionResult GetEducation()
        {
            try
            {
                int EducationId = Convert.ToInt32(HttpContext.Session.GetString("EducationId"));
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44358");
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    //string data = JsonConvert.SerializeObject(position);
                    //var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = client.GetAsync($"/api/educations/{EducationId}").Result;
                    //ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return Json(new { data = response.Content.ReadAsStringAsync().Result.ToString() });
                    }
                    else
                    {
                        return Json(new { data = "gagal" });
                    }
                }
            }
            catch (Exception)
            {
                return Json(new { data = "gagal" });
            }
        }

        [HttpPost]
        public ActionResult Register(ApplicantVM applicantVM)
        {
            applicantVM.EmployeeId = Convert.ToInt32(HttpContext.Session.GetString("EmployeeId"));
            if(HttpContext.Session.GetString("EducationId") != "")
            {
                string check = AlreadyCheck(applicantVM).ToLower();
                if (!check.Equals("gagal"))
                {
                    if (check.Contains("true"))
                    {
                        DeleteFile(applicantVM);
                        return Json(new { data = "notest" });
                    }
                    else
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            client.BaseAddress = new Uri("https://localhost:44307");
                            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                            client.DefaultRequestHeaders.Accept.Add(contentType);
                            string data = JsonConvert.SerializeObject(applicantVM);
                            var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                            var response = client.PostAsync("/API/Applicants/Add", contentData).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                string message = SendEmail(applicantVM).ToLower();
                                if (message.Equals("sukses")) return Json(new { data = "berhasil" });
                                else
                                {
                                    DeleteFile(applicantVM);
                                    return Json(new { data = "gagal" });
                                }
                            }
                            else
                            {
                                DeleteFile(applicantVM);
                                return Json(new { data = "gagal" });
                            }
                        }
                    }
                }
                else 
                {
                    DeleteFile(applicantVM);
                    return Json(new { data = "nodata" });
                }
            }
            else
            {
                DeleteFile(applicantVM);
                return Json(new { data = "nodata" });
            }
        }

        [HttpPost]
        public string AlreadyCheck(ApplicantVM applicantVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(applicantVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("/API/Applicants/Check", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    var allData = response.Content.ReadAsStringAsync().Result.ToString();
                    return allData;
                }
                else
                {
                    return "gagal";
                }
            }
            
        }

        [HttpPost]
        public string DeleteFile(ApplicantVM applicantVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(applicantVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("/API/Applicants/Delete", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    return "sukses";
                }
                else
                {
                    return "gagal";
                }
            }

        }

        // Upload File
        [HttpPost]
        public ActionResult Upload(IList<IFormFile> files)
        {
            if(HttpContext.Session.GetString("EducationId") != "")
            {
                foreach (IFormFile source in files)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(source.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension

                    var objfiles = new ApplicantVM()
                    {
                        FileName = fileName,
                        FileType = fileExtension,
                        CreatedOn = DateTime.Now
                    };

                    using (var target = new MemoryStream())
                    {
                        source.CopyTo(target);
                        objfiles.DataFile = target.ToArray();
                    }

                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44307");
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string data = JsonConvert.SerializeObject(objfiles);
                        var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                        var response = client.PostAsync("/API/Applicants/AddFile", contentData).Result;
                        //var upload = client.PostAsync("/API/Applicants");
                        if (response.IsSuccessStatusCode)
                        {
                            return Json(new { name = objfiles.FileName, type = objfiles.FileType, date = objfiles.CreatedOn, files = objfiles.DataFile, data = "Upload Sukses" });
                        }
                        else
                        {
                            return Json(new { data = "Upload Gagal" });
                        }
                        //return View();
                    }
                }
                return Json(new { data = "Error" });
            }
            return Json(new { data = "Error" });
        }

        [HttpPost]
        private string SendEmail(ApplicantVM applicantVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(applicantVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                try
                {
                    var response = client.PostAsync("/API/Applicants/SendEmail", contentData).Result;
                    //var upload = client.PostAsync("/API/Applicants");
                    //return "sukses";
                    if (response.IsSuccessStatusCode)
                    {
                        return "sukses";
                    }
                    else
                    {
                        return "gagal";
                    }
                }
                catch (Exception)
                {
                    return "sukses";
                }

                //return View();
            }
        }

        // Update Page Controller
        public IActionResult Update()
        {
            if (HttpContext.Session.GetString("Application").Equals("Portal"))
            {
                return View();
            }
            else return Redirect("~/Account/Index");
        }

        [HttpPut]
        public ActionResult UpdateData(EditProfileVM editProfileVM)
        {
            editProfileVM.EmployeeId = Convert.ToInt32(HttpContext.Session.GetString("EmployeeId"));
            editProfileVM.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44358");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                var token = HttpContext.Session.GetString("Token");
                char[] trimChars = { '/', '"' };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim(trimChars));

                string data = JsonConvert.SerializeObject(editProfileVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PutAsync("/API/Accounts/EditProfile", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { data = "sukses", url = Url.Action("Logout", "Registration") , email = HttpContext.Session.GetString("Email"), password = HttpContext.Session.GetString("Password") });
                }
                else
                {
                    return Json(new { data = "gagal" });
                }
                //return View();
            }
        }

    }
}
