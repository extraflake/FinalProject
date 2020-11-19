using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Portal.Bases;
using Portal.Context;
using Portal.Models;
using Portal.Repositories.Data;
using Portal.ViewModel;

namespace Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : BaseController<Applicant, ApplicantRepository>
    {
        private readonly MyContext myContext;
        public ApplicantsController(ApplicantRepository repository, MyContext myContext) : base(repository)
        {
            this.myContext = myContext;
        }

        [HttpPost(nameof(Add))]
        public async Task<ActionResult> Add(ApplicantVM applicantVM)
        {
            var Position = await myContext.Positions.FindAsync(applicantVM.PositionId);
            var Reference = await myContext.References.FindAsync(applicantVM.ReferenceId);
            var listSkills = new List<Skill>();
            foreach (var item in applicantVM.SkillId)
            {
                var getSkill = await myContext.Skills.FindAsync(item);
                if (getSkill != null)
                    listSkills.Add(getSkill);
            }
            var data = new Applicant()
            {
                //DocPath = applicantVM.DocPath,
                Position = Position,
                Reference = Reference,
                Skills = listSkills
            };
            await myContext.Applicants.AddAsync(data);
            var result = await myContext.SaveChangesAsync();
            return Ok(result);
        }
    }
}
