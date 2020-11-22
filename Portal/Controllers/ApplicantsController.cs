﻿using System;
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
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portal.Bases;
using Portal.Context;
using Portal.Models;
using Portal.Repositories.Data;
using Portal.Utility;
using Portal.ViewModel;
using File = Portal.Models.File;

namespace Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : BaseController<Applicant, ApplicantRepository>
    {
        private IConverter _converter;
        private readonly MyContext myContext;
        public ApplicantsController(ApplicantRepository repository, MyContext myContext, IConverter converter) : base(repository)
        {
            this.myContext = myContext;
            _converter = converter;
        }

        // Upload File to Database
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

        // Update Data on Database
        [HttpPost(nameof(Add))]
        public async Task<ActionResult> Add(ApplicantVM applicantVM)
        {
            var Doc = await myContext.Files.FirstOrDefaultAsync(x => x.CreatedOn == applicantVM.CreatedOn);

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


            var htmlTemplate = new HTMLTemplateGenerator(data);
            string body = htmlTemplate.GetHTMLString();

            byte[] file = CreatePDF(body);

            MemoryStream fileMM = new MemoryStream(file);
            MemoryStream memorystream = new MemoryStream(data.File.DataFile);

            string myEmail = "dionisiusyose11@gmail.com"; // Email dimasukkan terlebih dahulu

            var msgbody = new System.Text.StringBuilder();
            msgbody.AppendLine("<html><body>");
            msgbody.AppendLine("<h4>Tes Applicant Data</h4>");
            msgbody.AppendLine($"<p>Posisi      : {data.Position.Name}<br>");
            msgbody.AppendLine($"Referensi   : {data.Reference.Name}<br>");
            msgbody.AppendLine($"Nama file   : {data.File.Name}</p>");
            msgbody.AppendLine("</body></html>");

            string htmlBody = msgbody.ToString();

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(myEmail, "gmaildion1997"); // Password harus dimasukkan terlebih dahulua
            //MailMessage mm = new MailMessage("donotreply@gmail.com", myEmail, "This the data of applicant", body);
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("donotreply@gmail.com");
            mm.To.Add(myEmail);
            mm.Subject = "Applicant Data";
            mm.IsBodyHtml = true;
            mm.Body = $"Applicant data for {data.Position.Name}";

            //mm.Attachments.Add(new Attachment(memorystream, data.File.Name, mediaType: MediaTypeNames.Application.Pdf));
            mm.Attachments.Add(new Attachment(fileMM, $"{data.Position.Name}_{Doc.Name}.pdf", mediaType: MediaTypeNames.Application.Pdf));

            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mm);

            return Ok(result);
        }

        [HttpGet]
        public byte[] CreatePDF(string html)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = html,
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "PDFGeneratorTemplate", "app", "scss", "style.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file =  _converter.Convert(pdf);

            return file;
        }
    }
}
