using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.ViewModel
{
    public class EditProfileVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string User_Email { get; set; }        
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int Religion_Id { get; set; }
        public int Religion_Name { get; set; }  

        public string Univ_Id { get; set; }
        public string Univ_Name { get; set; }
        public string Dept_Id { get; set; }
        public string Dept_Name { get; set; }

        public int UnivDept_Id { get; set; }
        public string Level { get; set; }
        public string GPA { get; set; }
        public string GraduateYear { get; set; }
    }
}
