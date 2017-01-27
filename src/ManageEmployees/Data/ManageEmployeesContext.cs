using System;
using System.Linq;
using ManageEmployees.Models.Entities;
using ManageEmployees.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManageEmployees.Data
{
    public class ManageEmployeesContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        public ManageEmployeesContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Employee>().Property(s => s.DepartmentId).IsRequired();
            modelBuilder.Entity<Employee>().Property(s => s.BirthDate).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Employee>().Property(s => s.FirstName);
            modelBuilder.Entity<Employee>().Property(s => s.LastName).IsRequired();
            modelBuilder.Entity<Employee>().Property(s => s.JobPosition).HasDefaultValue(JobPosition.Junior);
            modelBuilder.Entity<Employee>().HasOne(s => s.Department).WithMany(s => s.Employees).HasForeignKey(d=>d.DepartmentId);

            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Department>().Property(s => s.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Department>().Property(s => s.Description).IsRequired();
            modelBuilder.Entity<Department>().HasMany(s => s.Employees);

            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<Contract>().Property(s => s.Amount);
            modelBuilder.Entity<Contract>().Property(s => s.EmployeeId).IsRequired();
            modelBuilder.Entity<Contract>().Property(s => s.StartDate).HasDefaultValue(DateTime.Now).IsRequired();
            modelBuilder.Entity<Contract>().Property(s => s.EndDate).HasDefaultValue(DateTime.Now).IsRequired();
            modelBuilder.Entity<Contract>().HasOne(s => s.Employee);

        }
    }
}
