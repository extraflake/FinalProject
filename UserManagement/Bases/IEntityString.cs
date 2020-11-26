using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Bases
{
    public interface IEntityString
    {
        string Id { get; set; }
    }
}
