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
        public DbSet<Position> Positions { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Reference> References { get; set; }

        public DbSet<File> Files { get; set; }
    }
}
