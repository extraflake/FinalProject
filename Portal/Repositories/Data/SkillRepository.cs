using Portal.Context;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Repositories.Data
{
    public class SkillRepository : GeneralRepository<Skill, MyContext>
    {
        public SkillRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
