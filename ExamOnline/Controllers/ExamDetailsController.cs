using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Dapper;

using ExamOnline.Context;
using ExamOnline.Dapper_ORM;
using ExamOnline.Models;
using ExamOnline.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamDetailsController : ControllerBase
    {
        public IConfiguration configuration;
        readonly MyContext myContext;
        readonly IDapper dapper;

        public ExamDetailsController(IConfiguration config, IDapper _dapper, MyContext _myContext)
        {
            configuration = config;
            dapper = _dapper;
            myContext = _myContext;
        }

        [HttpPost]
        public async Task<ActionResult> Create(ExamDetailVM examDetailVM)
        {
            //var getDuration = myContext.Durations.Where(x => x.ApplicantId == examDetailVM.ApplicantId).First();
            
            var query = from x in myContext.Durations
                        where x.ApplicantId == examDetailVM.ApplicantId
                        select x.Id;
            var getDurationId = query.FirstOrDefault();
            var listGrade = myContext.Grades.OrderBy(x => x.Id).Last();
            var data = new ExamDetail()
            {
                DurationId = getDurationId,
                FinalScore = 0,
                GradeId = listGrade.Id
            };
            await myContext.ExamDetails.AddAsync(data);
            await myContext.SaveChangesAsync();
            //return JsonResult(new { Data = model }, JsonRequestBehavior.AllowGet);

            return new JsonResult(data);
            //return Ok(result);
        }

        //[HttpGet("{Id}")]
        //public Task<ExamDetailVM> GetById(int Id)
        //{
        //    var dbparams = new DynamicParameters();
        //    dbparams.Add("@Id", Id, DbType.Int32);
        //    var result = Task.FromResult(dapper.Get<ExamDetailVM>("[SP_SelectById_ExamDetail]"
        //        , dbparams,
        //        commandType: CommandType.StoredProcedure));
        //    return result;

        //}

        [HttpGet]
        public Task<List<ExamDetailVM>> GetExamDetail()
        {
            var dbparams = new DynamicParameters();
            var result = Task.FromResult(dapper.GetAll<ExamDetailVM>("[SP_Select_ExamDetail]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
            return result;
        }

        [HttpPut]
        public async Task<ActionResult> Update(ExamDetailVM examDetailVM)
        {
            //var record = new Record { VideoRecord = examDetailVM.VideoRecord };
            //await myContext.Records.AddAsync(record);
            
            var getScore = await myContext.ExamDetails.FindAsync(examDetailVM.Id);
            getScore.FinalScore = examDetailVM.FinalScore;
            getScore.RecordVideo = examDetailVM.RecordVideo;

            //getScore.RecordId = myContext.Records.OrderBy(x => x.Id).Last().Id;


            var listGrade = myContext.Grades.OrderBy(x => x.Score);
            
            foreach (var data in listGrade)
            {
                if (getScore.FinalScore >= data.Score)
                {
                    getScore.GradeId = data.Id;
                }
            }

            var result = myContext.SaveChangesAsync();

            string MessageForUser = "Thanks for attempt the exam. Finish at " +DateTime.Now;
            string MessageForAdmin = "ApplicantId : " +examDetailVM.ApplicantId+ " has finish the exam. " +DateTime.Now;

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("afrarian44@gmail.com", "");
            MailMessage mm =
                new MailMessage("donotreply@gmail.com", examDetailVM.UserEmail
                , "Thanks!", MessageForUser);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mm);
            MailMessage mm1 =
                new MailMessage("donotreply@gmail.com", "kevinhendrawiliam@gmail.com"
                , "ExamADMIN", MessageForAdmin);
            mm1.BodyEncoding = UTF8Encoding.UTF8;
            mm1.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mm1);

            return Ok(result);
        }


    }
}
