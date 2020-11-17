using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.ViewModel
{
    public class UserRoleVM
    {
        public int Id { get; set; }

        public int User_UserId { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }

        public int Role_RoleId { get; set; }
        public string Role_Name { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
    }
}
