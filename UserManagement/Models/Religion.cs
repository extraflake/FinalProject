using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;
using UserManagement.Models;

namespace UserManagement.Microservices.Models
{
    [Table("TB_M_Religion")]
    public class Religion : IEntity
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee Employee { get; set; }
    }
}
