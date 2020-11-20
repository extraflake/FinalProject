using ExamOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    [Table("TB_M_Duration")]
    public class Duration : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public ExamDetail ExamDetail { get; set; }
    }
}
