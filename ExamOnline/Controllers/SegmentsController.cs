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
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentsController : BaseController<Segment, SegmentRepository>
    {
        private readonly MyContext myContext;
        public SegmentsController(SegmentRepository segmentRepository, MyContext _myContext): base(segmentRepository) 
        {
            myContext = _myContext;
        }

        [HttpGet(nameof(GetActive))]
        public List<Segment> GetActive()
        {
            var getSegment = myContext.Segments.Where(x => x.IsSegmentActive == true).ToList();
            return getSegment;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var segment = new Segment { Id = id };

            var cek = myContext.Questions.Where(x => x.SegmentId == segment.Id).Count();

            if (cek == 0)
            {
                myContext.Entry(segment).State = EntityState.Deleted;
                //myContext.Segments.Remove(segment);
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
