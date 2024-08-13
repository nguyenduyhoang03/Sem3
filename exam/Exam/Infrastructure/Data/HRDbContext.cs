using Exam.Core.Entities;
using Exam.src.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Exam.Infrastructure.Data
{
    public class HRDbContext : DbContext
    {
        public HRDbContext(DbContextOptions<HRDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .ToTable("Department_Tbl");

            modelBuilder.Entity<Employee>()
                .ToTable("Employee_Tbl");

            base.OnModelCreating(modelBuilder);
        }
    }
}
