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
            var listGrade = myContext.Grades.OrderBy(x => x.Id).Last();
            var getDuration = myContext.Durations.Find(examDetailVM.ApplicantId);
            var data = new ExamDetail()
            {
                DurationId = getDuration.Id,
                FinalScore = 0,
                GradeId = listGrade.Id
            };
            await myContext.ExamDetails.AddAsync(data);
            var result = await myContext.SaveChangesAsync();
            return Ok(result);
        }

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

            //int count = myContext.Grades.ToList().Count;
            //for (int i = count; i >= 0; i--)
            //{
            //    var getGrade = myContext.Grades.;
            //    if (getScore.FinalScore > getGrade.FindIndex(i))
            //        getScore.GradeId = i;
            //}

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
