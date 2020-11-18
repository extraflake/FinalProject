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
    public class ExamDetailsController : ControllerBase
    {
        public IConfiguration configuration;
        readonly IDapper dapper;

        public ExamDetailsController(IConfiguration config, IDapper _dapper)
        {
            configuration = config;
            dapper = _dapper;
        }

        [HttpPost]
        public Task<List<ExamDetailVM>> Create(ExamDetailVM examDetailVM)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@DurationId", examDetailVM.DurationId, DbType.Int32);
            dbparams.Add("@GradeId", examDetailVM.GradeId, DbType.Int32);
            dbparams.Add("@FinalScore", examDetailVM.FinalScore, DbType.Int32);
            var result = Task.FromResult(dapper.GetAll<ExamDetailVM>("[SP_Create_ExamDetail]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }


    }
}
