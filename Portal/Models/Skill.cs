using Portal.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    [Table("TB_M_Skill")]
    public class Skill : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ApplicantSkill> ApplicantSkills { get; set; }
    }
}
