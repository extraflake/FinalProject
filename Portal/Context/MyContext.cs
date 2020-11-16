using Microsoft.EntityFrameworkCore;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Context
{
    public class MyContext : DbContext
    {
        public MyContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<Applicant> Applicants { get; set; }
    }
}
