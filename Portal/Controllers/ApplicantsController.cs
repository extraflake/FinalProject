using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
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

            //var getFile = Download(Doc.Id);
            MemoryStream memorystream = new MemoryStream(data.File.DataFile);

            //System.Net.Mail.Attachment attachment;
            //attachment = new System.Net.Mail.Attachment(getFile.FileDownloadName);

            string myEmail = ""; // Email dimasukkan terlebih dahulu
            string body = "Applicant data \n" +
                $"Posisi    : {data.Position.Name} \n" +
                $"Referensi : {data.Reference.Name} \n" +
                $"Skill     : {data.Skills.ToList()} \n" +
                $"File      : {data.File.Name}";

            var msgbody = new System.Text.StringBuilder();
            msgbody.AppendLine("<html><body>");
            msgbody.AppendLine("<h4>Tes Applicant Data</h4>");
            msgbody.AppendLine($"<p>Posisi      : {data.Position.Name}</p>");
            msgbody.AppendLine($"<p>Referensi   : {data.Reference.Name}</p>");
            msgbody.AppendLine($"<p>Nama file   : {data.File.Name}</p>");
            msgbody.AppendLine("</body></html>");

            string htmlBody = msgbody.ToString();

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(myEmail, ""); // Password harus dimasukkan terlebih dahulua
            //MailMessage mm = new MailMessage("donotreply@gmail.com", myEmail, "This the data of applicant", body);
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("donotreply@gmail.com");
            mm.To.Add(myEmail);
            mm.Subject = "Applicant Data";
            mm.IsBodyHtml = true;
            mm.Body = htmlBody;

            mm.Attachments.Add(new Attachment(memorystream, data.File.Name, mediaType: MediaTypeNames.Application.Pdf));

            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mm);

            return Ok(result);
        }

        public FileResult Download(int id)
        {
            var file = myContext.Files.SingleOrDefault(a => a.Id == id);
            string fileName = file.Name;
            byte[] pdfasBytes = file.DataFile;
            return File(pdfasBytes, "application/pdf", fileName);
        }

        public void sendEmail()
        {
            //SmtpClient client = new SmtpClient();
            //client.Port = 587;
            //client.Host = "smtp.gmail.com";
            //client.EnableSsl = true;
            //client.Timeout = 10000;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Credentials = new NetworkCredential("dionisiusyose11@gmail.com", "gmaildion1997");
            //MailMessage mm = new MailMessage("donotreply@gmail.com", user.UserEmail, "Secret!!!!", passwordText);
            //mm.BodyEncoding = UTF8Encoding.UTF8;
            //mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            //client.Send(mm);
        }
    }
}
