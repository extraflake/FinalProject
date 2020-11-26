using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Client.ViewModel
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

        //Record
        public int RecordId { get; set; }
        public byte[] VideoRecord { get; set; }

        //Duration
        public int DurationId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ApplicantId { get; set; }

        //Schedule
        public int ScheduleId { get; set; }
        public DateTime ScheduleTime { get; set; }
        public bool IsActive { get; set; }
    }
    public class ExamDetailJson
    {
        [JsonProperty("data")]
        public IList<ExamDetailVM> data { get; set; }
    }
}
