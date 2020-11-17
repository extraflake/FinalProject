using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.ViewModel
{
    public class ExamDetailVM
    {
        public int Id { get; set; }
        //exam details
        public int FinalScore { get; set; }
        //grade
        public int GradeId { get; set; }
        public int Score { get; set; }
        public string Grades { get; set; }

        //Duration
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Schedule
        public DateTime ScheduleTime { get; set; }
    }
}
