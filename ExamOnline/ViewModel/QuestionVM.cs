using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.ViewModel
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

        //segment
        public int SegmentId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int QuestionQuantity { get; set; }
    }
}
