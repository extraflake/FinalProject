using ExamOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    [Table("TB_M_Record")]
    public class Record : IEntity
    {
        [Key]
        public int Id { get; set; }
        public byte[] VideoRecord { get; set; }
    }
}
