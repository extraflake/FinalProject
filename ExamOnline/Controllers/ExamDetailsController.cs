using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Dapper_ORM;
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



    }
}
