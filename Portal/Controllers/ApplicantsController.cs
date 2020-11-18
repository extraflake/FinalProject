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
using Portal.Dapper_ORM;
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
                DocPath = applicantVM.DocPath,
                Position = Position,
                Reference = Reference,
                Skills = listSkills
            };
            await myContext.Applicants.AddAsync(data);
            var result = await myContext.SaveChangesAsync();
            return Ok(result);
        }
        //public async Task<string> Add(ApplicantVM applicantVM)
        //{
        //    var dbparams = new DynamicParameters();
        //    dbparams.Add("@DocPath", applicantVM.DocPath, DbType.String);
        //    dbparams.Add("@PositionId", applicantVM.PositionId, DbType.Int32);
        //    dbparams.Add("@ReferenceId", applicantVM.ReferenceId, DbType.Int32);
        //    dbparams.Add("@SkillId", applicantVM.SkillId, DbType.Int32);
        //    var result = await Task.FromResult(dapper.Insert<ApplicantVM>("[SP_Insert_Applicant]", dbparams, commandType: CommandType.StoredProcedure));

        //    for (int x = 0; x <= 1; x++)
        //    {
        //        await Task.FromResult(dapper.Insert<ApplicantVM>("[SP_Insert_ApplicantSkill]", dbparams, commandType: CommandType.StoredProcedure));
        //    }
        //    string hasil = Convert.ToString(result);

        //    return hasil;
        //}
    }
}
