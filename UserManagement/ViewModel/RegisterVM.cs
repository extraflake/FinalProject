using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.ViewModel
{
    public class RegisterVM
    {
        public int Id { get; set; }

        public int User_UserId { get; set; }
        public int Role_RoleId { get; set; }
        public string Role_Name { get; set; }

        public int EmployeeId { get; set; }
        public int UserID { get; set; }
        public int EducationID { get; set; }

        public string Username { get; set; }
        public string Application { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }        
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int ReligionID { get; set; }        
    }
}
