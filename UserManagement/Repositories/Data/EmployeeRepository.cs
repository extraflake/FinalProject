using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Microservices.Context;
using UserManagement.Models;

namespace UserManagement.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, MyContext>
    {
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
