using ExamOnline.Context;
using ExamOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Repositories.Data
{
    public class GradeRepository : GeneralRepository<Grade, MyContext>
    {
        public GradeRepository(MyContext myContext) : base(myContext) { }
    }
}
