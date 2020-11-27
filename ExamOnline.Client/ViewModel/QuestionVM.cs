using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Client.ViewModel
{
    public class QuestionVM
    {
        public int Id { get; set; }
        //Question
        public string Quest { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }
        public int Point { get; set; }
        public string ApplicantAnswer { get; set; }

        //segment
        public int SegmentId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int QuestionQuantity { get; set; }
        public bool IsSegmentActive { get; set; }
    }
    public class SegmentJson
    {
        [JsonProperty("data")]
        public IList<QuestionVM> data { get; set; }
    }
    
    public class QuestionJson
    {
        [JsonProperty("data")]
        public IList<QuestionVM> data { get; set; }
    }
}
