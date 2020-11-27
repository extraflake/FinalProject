using ExamOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    [Table("TB_M_ExamDetail")]
    public class ExamDetail : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int FinalScore { get; set; }
        public int DurationId { get; set; }
        public Duration Duration { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public int RecordId { get; set; }
        public Record Record { get; set; }
    }
}
