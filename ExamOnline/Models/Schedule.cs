using ExamOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    [Table("TB_M_Schedule")]
    public class Schedule : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime ScheduleTime { get; set; }
        public Duration Duration { get; set; }
        public bool IsActive { get; set; }
    }
}
