using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Microservices.Context;
using UserManagement.Models;

namespace UserManagement.Repositories.Data
{
    public class UserApplicationRepository : GeneralRepository<UserApplication, MyContext>
    {
        public UserApplicationRepository(MyContext myContext) :base(myContext)
        {

        }
    }
}
