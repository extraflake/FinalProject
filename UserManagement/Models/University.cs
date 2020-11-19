using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;
using UserManagement.Microservices.Models;

namespace UserManagement.Microservices.Models
{
    [Table("TB_M_University")]
    public class University : IEntityString
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Education> UnivDepts { get; set; }
    }
}
