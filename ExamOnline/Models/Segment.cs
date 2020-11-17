using ExamOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    [Table("TB_M_Segment")]
    public class Segment : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
