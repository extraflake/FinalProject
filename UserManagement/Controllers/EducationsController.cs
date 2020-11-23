using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Bases;
using UserManagement.Microservices.Models;
using UserManagement.Repositories.Data;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : BasesController<Education, EducationReposiitory>
    {
        public EducationsController(EducationReposiitory education): base(education)
        {

        }
    }
}
