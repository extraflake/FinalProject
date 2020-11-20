using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;

namespace UserManagement.Models
{
    [Table("TB_M_University")]
    public class University
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Education> UnivDepts { get; set; }
    }
}
