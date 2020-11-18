using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ExamOnline.Context;
using ExamOnline.Dapper_ORM;
using ExamOnline.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DurationsController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IDapper _dapper;
        private readonly MyContext _myContext;

        public DurationsController(IDapper dapper, IConfiguration configuration, MyContext myContext)
        {
            _dapper = dapper;
            _configuration = configuration;
            _myContext = myContext;
        }
        [HttpPost]
        public async Task<int>Create(ExamDetailVM examDetailVM)
        {
            var dbparam = new DynamicParameters();
            dbparam.Add("@ApplicantId", examDetailVM.ApplicantId, DbType.Int32);
            dbparam.Add("@ScheduleId", examDetailVM.ScheduleId, DbType.Int32);
            dbparam.Add("@StartTime", examDetailVM.StartTime, DbType.DateTime2);
            dbparam.Add("@EndTime", examDetailVM.EndTime, DbType.DateTime2);
            var result = await Task.FromResult(_dapper.Insert<int>("[SP_Insert_Duration]", dbparam, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
