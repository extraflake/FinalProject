using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        public FileResult Download(int id)
        {
            var file = myContext.Files.SingleOrDefault(a => a.Id == id);
            string fileName = file.Name;
            byte[] pdfasBytes = file.DataFile;
            return File(pdfasBytes, "application/pdf", fileName);
        }


        [HttpPost]
        public ActionResult Index(IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    var objfiles = new File()
                    {
                        Id = 0,
                        Name = newFileName,
                        FileType = fileExtension,
                        CreatedOn = DateTime.Now
                    };

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.DataFile = target.ToArray();
                    }

                    myContext.Files.Add(objfiles);
                    myContext.SaveChanges();
                }
            }
            return Ok("Sukses File");
        }

        [HttpPost(nameof(Add))]
        public async Task<ActionResult> Add(ApplicantVM applicantVM)
        {
            var Doc = await myContext.Files.FindAsync(applicantVM.FileId);
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
            return Ok(result);
        }
    }
}
