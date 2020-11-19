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
        public int ExamId { get; set; }
        public int FinalScore { get; set; }
        //grade
        public int GradeId { get; set; }
        public int Score { get; set; }
        public string Grades { get; set; }

        //Duration
        public int DurationId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ApplicantId { get; set; }

        //Schedule
        public int ScheduleId { get; set; }
        public DateTime ScheduleTime { get; set; }
    }
}
