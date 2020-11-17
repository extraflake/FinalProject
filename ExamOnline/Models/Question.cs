using ExamOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    [Table("TB_M_Question")]
    public class Question : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Quest { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }
        public int Point { get; set; }
        public int SegmentId { get; set; }
        public Segment Segment { get; set; }
    }
}
