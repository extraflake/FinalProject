using Portal.Context;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Repositories.Data
{
    public class ReferenceRepository : GeneralRepository<Reference, MyContext>
    {
        public ReferenceRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
