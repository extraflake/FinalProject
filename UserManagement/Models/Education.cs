using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Microservices.Models;

namespace UserManagement.Models
{
    [Table("TB_T_Education")]
    public class Education
    {
        [Key]
        public int Id { get; set; }        
        public University University { get; set; }        
        public Department Department { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public string GraduateYear { get; set; }
    }
}
