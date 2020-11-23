using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ExamOnline.Dapper_ORM;
using ExamOnline.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        public IConfiguration configuration;
        readonly IDapper dapper;

        public QuestionsController(IConfiguration config, IDapper _dapper)
        {
            configuration = config;
            dapper = _dapper;
        }

        [HttpPost]
        public async Task<int> Create(QuestionVM questionVM)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@Quest", questionVM.Quest, DbType.String);
            dbparams.Add("@AnswerA", questionVM.AnswerA, DbType.String);
            dbparams.Add("@AnswerB", questionVM.AnswerB, DbType.String);
            dbparams.Add("@AnswerC", questionVM.AnswerC, DbType.String);
            dbparams.Add("@AnswerD", questionVM.AnswerD, DbType.String);
            dbparams.Add("@CorrectAnswer", questionVM.CorrectAnswer, DbType.String);
            dbparams.Add("@SegmentId", questionVM.SegmentId, DbType.Int32);
            dbparams.Add("@Point", questionVM.Point, DbType.Int32);
            var result = await Task.FromResult(dapper.Insert<int>("[SP_Create_Question]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
            return result;
        }
        
        [HttpPost(nameof(GetRandom))]
        public Task<List<QuestionVM>> GetRandom(QuestionVM questionVM)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@SegmentId", questionVM.SegmentId, DbType.Int32);
            var result = Task.FromResult(dapper.GetAll<QuestionVM>("[SP_Random_Question]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
            return result;
        }

        [HttpPost(nameof(GetById))]
        public Task<QuestionVM> GetById(QuestionVM questionVM)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@Id", questionVM.Id, DbType.Int32);
            var result = Task.FromResult(dapper.Get<QuestionVM>("[SP_GetById_Question]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
                return result;
        }

        [HttpGet]
        public Task<List<QuestionVM>> GetAllQuestion()
        {
            var dbparams = new DynamicParameters();
            var result = Task.FromResult(dapper.GetAll<QuestionVM>("[SP_Select_Question]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
            return result;
        }

        [HttpPut]
        public async Task<int> Update(QuestionVM questionVM)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@Id", questionVM.Id, DbType.String);
            dbparams.Add("@Quest", questionVM.Quest, DbType.String);
            dbparams.Add("@AnswerA", questionVM.AnswerA, DbType.String);
            dbparams.Add("@AnswerB", questionVM.AnswerB, DbType.String);
            dbparams.Add("@AnswerC", questionVM.AnswerC, DbType.String);
            dbparams.Add("@AnswerD", questionVM.AnswerD, DbType.String);
            dbparams.Add("@CorrectAnswer", questionVM.CorrectAnswer, DbType.String);
            dbparams.Add("@SegmentId", questionVM.SegmentId, DbType.Int32);
            dbparams.Add("@Point", questionVM.Point, DbType.Int32);
            var result = await Task.FromResult(dapper.Update<int>("[SP_Update_Question]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
            return result;
        }

        [HttpPost(nameof(Delete))]
        public Task<int> Delete(QuestionVM questionVM)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@Id", questionVM.Id, DbType.Int32);
            var result = Task.FromResult(dapper.Execute("[SP_Delete_Question]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
                return result;
        }
    }
}
