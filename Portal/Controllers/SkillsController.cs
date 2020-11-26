using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Bases;
using Portal.Models;
using Portal.Repositories.Data;

namespace Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : BaseController<Skill, SkillRepository>
    {
        public SkillsController(SkillRepository repository) : base(repository)
        {
        }
    }
}