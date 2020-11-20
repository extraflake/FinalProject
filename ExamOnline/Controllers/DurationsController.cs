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
            var result = await Task.FromResult(_dapper.Insert<int>("[SP_Create_Duration]", dbparam, commandType: CommandType.StoredProcedure));
            return result;
        }

        [HttpPut(nameof(UpdateStart))]
        public async Task<int> UpdateStart(ExamDetailVM examDetailVM)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@Id", examDetailVM.Id, DbType.Int32);
            dbparams.Add("@StartTime", examDetailVM.StartTime, DbType.DateTime);
            var result = await Task.FromResult(_dapper.Update<int>("[SP_UpdateStart_Duration]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
            return result;
        }

        [HttpPut(nameof(UpdateEnd))]
        public async Task<int> UpdateEnd(ExamDetailVM examDetailVM)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@Id", examDetailVM.Id, DbType.Int32);
            dbparams.Add("@EndTime", examDetailVM.EndTime, DbType.DateTime);
            var result = await Task.FromResult(_dapper.Update<int>("[SP_UpdateEnd_Duration]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
