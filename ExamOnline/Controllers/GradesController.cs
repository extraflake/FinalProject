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
    public class GradesController : BaseController<Grade, GradeRepository>
    {
        private readonly MyContext myContext;
        public GradesController(GradeRepository gradeRepository, MyContext _myContext) : base(gradeRepository) 
        {
            myContext = _myContext;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var grade = new Grade { Id = id };

            var cek = myContext.ExamDetails.Where(x => x.GradeId == grade.Id).Count();

            if (cek == 0)
            {
                //myContext.Entry(segment).State = EntityState.Deleted;
                myContext.Grades.Remove(grade);
                var result = await myContext.SaveChangesAsync();
                return Ok("Data Berhasil di Hapus");
            }
            else
            {
                return NotFound("Data tidak ditemukan atau berelasi dengan tabel lain");
            }
        }

    }
}
