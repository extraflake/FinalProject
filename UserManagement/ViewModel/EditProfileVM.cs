using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.ViewModel
{
    public class EditProfileVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int ReligionId { get; set; }
        public int EmployeeId { get; set; }

        public string User_Email { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }

        public string UniversityId { get; set; }
        public string DepartmentId { get; set; }

        public string GPA { get; set; }
        public string Degree { get; set; }
        public string GraduateYear { get; set; }

    }
}
