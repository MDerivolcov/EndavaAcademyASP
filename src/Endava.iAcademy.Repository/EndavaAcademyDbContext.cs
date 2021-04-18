using Endava.iAcademy.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Endava.iAcademy.Repository
{
    public class EndavaAcademyDbContext : DbContext
    {
        public EndavaAcademyDbContext()
        {
        }
        
        private readonly string _connectionString = @"Data Source =.\SQLEXPRESS; Initial Catalog = EndavaAcademy; Integrated Security=True";

        public EndavaAcademyDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<User> Users { get; set; }
    }
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
