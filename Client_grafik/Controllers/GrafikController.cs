﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserManagement.ViewModel;

namespace Client_grafik.Controllers
{
    public class GrafikController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUniversity()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://haidaraldi-001-site1.htempurl.com");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                var response = client.GetAsync("api/Accounts/CountUniversity").Result;

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

        public IActionResult Department()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDepartment()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://haidaraldi-001-site1.htempurl.com");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                var response = client.GetAsync("api/Accounts/CountDepartment").Result;

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
