using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Bases;
using ExamOnline.Context;
using ExamOnline.Models;
using ExamOnline.Repositories.Data;
using ExamOnline.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : BaseController<Schedule, ScheduleRepository>
    {
        readonly MyContext myContext;
        public SchedulesController(ScheduleRepository scheduleRepository, MyContext _myContext) : base(scheduleRepository) 
        {
            myContext = _myContext;
        }


        [HttpPut]
        public async Task<ActionResult> Update(ExamDetailVM examDetailVM)
        {
            var getSchedule = myContext.Schedules.Find(examDetailVM.ScheduleId);
            getSchedule.IsActive = examDetailVM.IsActive;

            var result = await myContext.SaveChangesAsync();
            return Ok(result);
        }

    }
}
