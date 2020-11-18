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
       readonly IDapper _dapper;

        public DurationsController(IDapper dapper, IConfiguration configuration)
        {
            _dapper = dapper;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<int>Create(ExamDetailVM examDetailVM)
        {
            var dbparam = new DynamicParameters();
            dbparam.Add("@ApplicantId", examDetailVM.ApplicantId, DbType.Int32);
            dbparam.Add("@ScheduleId", examDetailVM.ScheduleId, DbType.Int32);
            dbparam.Add("@StartTime", examDetailVM.StartTime, DbType.DateTime);
            dbparam.Add("@EndTime", examDetailVM.EndTime, DbType.DateTime);
            var result = await Task.FromResult(_dapper.Insert<int>("[SP_Create_Duration]", dbparam, commandType: CommandType.StoredProcedure));
            return result;
        }

        [HttpGet]
        public Task<List<ExamDetailVM>> Get()
        {
            var dbparams = new DynamicParameters();
            var result = Task.FromResult(_dapper.GetAll<ExamDetailVM>("[SP_Select_Duration]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
            return result;
        }

        [HttpPut]
        public async Task<ExamDetailVM> Update(ExamDetailVM examDetailVM)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@Id", examDetailVM.Id, DbType.Int32);
            dbparams.Add("@ApplicantId", examDetailVM.ApplicantId, DbType.Int32);
            dbparams.Add("@ScheduleId", examDetailVM.ScheduleId, DbType.Int32);
            dbparams.Add("@StartTime", examDetailVM.StartTime, DbType.DateTime);

            var result = await Task.FromResult(_dapper.Update<ExamDetailVM>("[SP_Update_Question]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
            return result;
        }
        [HttpDelete]
        public Task<int> Delete(ExamDetailVM examDetailVM)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@Id", examDetailVM.Id, DbType.Int32);
            var result = Task.FromResult(_dapper.Execute("[SP_Delete_Duration]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
