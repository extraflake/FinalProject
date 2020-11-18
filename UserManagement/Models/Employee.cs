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
        public int ReligionID { get; set; }
        public Religion Religion { get; set; }
        public int UnivDeptID { get; set; }
        public UnivDept UnivDept{ get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }        

    }
}
