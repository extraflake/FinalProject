using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Bases;
using ExamOnline.Context;
using ExamOnline.Models;
using ExamOnline.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : BaseController<Record, RecordRepository>
    {
        private readonly MyContext myContext;
        public RecordController(RecordRepository recordRepository, MyContext _myContext) : base(recordRepository)
        {
            myContext = _myContext;
        }



    }
}
