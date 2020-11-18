using Portal.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    [Table("TB_M_Applicant")]
    public class Applicant : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string DocPath { get; set; }
        public bool AlreadyCheck { get; set; }
        public bool AlreadyTest { get; set; }

        public Position Position { get; set; }
        public Reference Reference { get; set; }

        public int EmployeeId { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }
}
