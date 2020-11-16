using ExamOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    [Table("TB_M_Score")]
    public class Score : IEntity
    {
        [Key]
        public int Id { get; set; }
        public double FinalScore { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
