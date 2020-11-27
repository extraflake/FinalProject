using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            var getScore = await myContext.ExamDetails.FindAsync(examDetailVM.Id);
            getScore.FinalScore = examDetailVM.FinalScore;

            var listGrade = myContext.Grades.OrderBy(x => x.Score);
            foreach (var data in listGrade)
            {
                if (getScore.FinalScore >= data.Score)
                {
                    getScore.GradeId = data.Id;
                }
            }

            var result = myContext.SaveChangesAsync();
            return Ok(result);
        }


    }
}
