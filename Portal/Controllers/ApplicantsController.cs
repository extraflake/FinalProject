using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portal.Bases;
using Portal.Context;
using Portal.Models;
using Portal.Repositories.Data;
using Portal.ViewModel;
using File = Portal.Models.File;

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

        [HttpPost(nameof(AddFile))]
        public async Task<ActionResult> AddFile(ApplicantVM applicantVM)
        {

            var data = new File()
            {
                Name = applicantVM.FileName,
                FileType = applicantVM.FileType,
                CreatedOn = applicantVM.CreatedOn,
                DataFile = applicantVM.DataFile
            };
            await myContext.Files.AddAsync(data);
            var result = await myContext.SaveChangesAsync();

            return Ok(result);
        }

        [HttpPost(nameof(Add))]
        public async Task<ActionResult> Add(ApplicantVM applicantVM)
        {
            //var query = from x in myContext.Files
            //            where x.CreatedOn == applicantVM.CreatedOn
            //            select x;
            //var Doc = await query.FirstOrDefaultAsync();

            var Doc = await myContext.Files.FirstOrDefaultAsync(x => x.CreatedOn == applicantVM.CreatedOn);
            //var Doc = myContext.Files.OrderBy(x => x.Id).Last();

            //var Doc = await myContext.Files.FindAsync(applicantVM.FileId);
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
                File = Doc,
                Position = Position,
                Reference = Reference,
                Skills = listSkills
            };
            await myContext.Applicants.AddAsync(data);
            var result = await myContext.SaveChangesAsync();

            var getFile = Download(Doc.Id);

            return Ok(result);
        }



        public FileResult Download(int id)
        {
            var file = myContext.Files.SingleOrDefault(a => a.Id == id);
            string fileName = file.Name;
            byte[] pdfasBytes = file.DataFile;
            return File(pdfasBytes, "application/pdf", fileName);
        }
    }
}
