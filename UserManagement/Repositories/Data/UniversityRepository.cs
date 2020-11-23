using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Microservices.Context;
using UserManagement.Microservices.Models;

namespace UserManagement.Repositories.Data
{
    public class UniversityRepository: GeneralRepositoryString<University, MyContext>
    {
        public UniversityRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
