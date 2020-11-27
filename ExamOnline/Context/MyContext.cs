using ExamOnline.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Duration> Durations { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ExamDetail> ExamDetails { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Record> Records { get; set; }
    }
}
