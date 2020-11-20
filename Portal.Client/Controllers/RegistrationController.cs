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

        // Register Page Controller

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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(ApplicantVM applicantVM)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string data = JsonConvert.SerializeObject(applicantVM);
                var contentData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = client.PostAsync("/API/Applicants/Add", contentData).Result;
                //var upload = client.PostAsync("/API/Applicants");
                if (response.IsSuccessStatusCode)
                {

                    return Json(new { data = "Berhasil" });
                }
                else
                {
                    return Content("GAGAL");
                }
                //return View();
            }
        }

        [HttpPost]
        public ActionResult Upload(IList<IFormFile> files)
        {
            foreach (IFormFile source in files)
            {
                //Getting FileName
                var fileName = Path.GetFileName(source.FileName);
                //Getting file Extension
                 var fileExtension = Path.GetExtension(fileName);
                // concatenating  FileName + FileExtension
                //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                var objfiles = new FileVM()
                {
                    Name = fileName,
                    FileType = fileExtension,
                    CreatedOn = DateTime.Now
                };

                using (var target = new MemoryStream())
                {
                    source.CopyTo(target);
                    objfiles.DataFile = target.ToArray();
                }
                return Json(new { name = objfiles.Name, type = objfiles.FileType, date = objfiles.CreatedOn, files = objfiles.DataFile });
            }

            return Json(new {data = "success" });
        }


        // Update Page Controller
        public IActionResult Update()
        {
            return View();
        }
    }
}
