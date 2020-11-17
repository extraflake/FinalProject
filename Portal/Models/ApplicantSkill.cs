using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    [Table("TB_T_ApplicantSkill")]
    public class ApplicantSkill
    {
        [Key]
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
