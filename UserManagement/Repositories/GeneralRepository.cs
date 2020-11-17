using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Repositories
{
    public class GeneralRepository <Tentity, IContext> : IRepository<TEntiry>
        where Tentity : class, IEntity
        where IContext : MyContext
    {
        private readonly MyContext _myContext;
        public GeneralRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        
    }
}
