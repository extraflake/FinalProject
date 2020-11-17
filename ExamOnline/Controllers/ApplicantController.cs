using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Bases;
using ExamOnline.Models;
using ExamOnline.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : BaseController<Applicant, ApplicantRepository>
    {
        public ApplicantController(ApplicantRepository applicantRepository) : base(applicantRepository) { }
    }
}
