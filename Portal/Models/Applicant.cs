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
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Academic { get; set; }
        public string Department { get; set; }
        public string Level { get; set; }
        public string GraduationYear { get; set; }
        public string Position { get; set; }
        public string GPA { get; set; }
        public string City { get; set; }
        public string Skill { get; set; }
        public string DocPath { get; set; }
        public bool AlreadyTest { get; set; }
    }
}
