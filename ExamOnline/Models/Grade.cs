using ExamOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    [Table("TB_M_Grade")]
    public class Grade : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }
        public string Grades { get; set; }
        public ExamDetail ExamDetail { get; set; }
    }
}
