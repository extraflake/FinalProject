using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;
using UserManagement.Microservices.Models;

namespace UserManagement.Models
{

    [Table("TB_M_Employee")]
    public class Employee : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string University { get; set; }
        public string Majors { get; set; }
        public string Level { get; set; }
        public string GraduateYear { get; set; }
        public string GPA { get; set; }
    }
}
