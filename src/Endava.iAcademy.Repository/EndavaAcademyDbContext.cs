using Endava.iAcademy.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Endava.iAcademy.Repository
{
    public class EndavaAcademyDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<User> Users { get; set; }

        public EndavaAcademyDbContext(DbContextOptions<EndavaAcademyDbContext> options)
              : base(options)
        {
            Database.EnsureCreated();  
        }
    }
}
