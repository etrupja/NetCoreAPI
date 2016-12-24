using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageEmployees.Models.Entities;
using ManageEmployees.Models.Enums;

namespace ManageEmployees.Data
{
    public class ManageEmployeesDbInitializer
    {
        private static ManageEmployeesContext context;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (ManageEmployeesContext) serviceProvider.GetService(typeof (ManageEmployeesContext));
            InitializeDatabase();
        }

        private static void InitializeDatabase()
        {
            if (!context.Departments.Any())
            {
                Department dpt1 = new Department { Name = "Development" };
                Department dpt2 = new Department { Name = "Marketing" };
                Department dpt3 = new Department { Name = "Consulting" };

                context.Departments.Add(dpt1); //id=1
                context.Departments.Add(dpt2); //id=2
                context.Departments.Add(dpt3); //id=3

                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                Employee emp1 = new Employee
                {
                    FirstName = "Ervis",
                    LastName = "Trupja",
                    Age = 24,
                    BirthDate = DateTime.Now.AddYears(-24),
                    DepartmentId = 1,
                    JobPosition = JobPosition.Junior
                };
                Employee emp2 = new Employee
                {
                    FirstName = "Ervis2",
                    LastName = "Trupja2",
                    Age = 23,
                    BirthDate = DateTime.Now.AddYears(-23),
                    DepartmentId = 1,
                    JobPosition = JobPosition.Senior
                };
                Employee emp3 = new Employee
                {
                    FirstName = "Ervis3",
                    LastName = "Trupja3",
                    Age = 20,
                    BirthDate = DateTime.Now.AddYears(-20),
                    DepartmentId = 2,
                    JobPosition = JobPosition.Trainee
                };
                Employee emp4 = new Employee
                {
                    FirstName = "Ervis",
                    LastName = "Trupja",
                    Age = 30,
                    BirthDate = DateTime.Now.AddYears(-30),
                    DepartmentId = 3,
                    JobPosition = JobPosition.Senior
                };
                context.Employees.Add(emp1);
                context.Employees.Add(emp2);
                context.Employees.Add(emp3);
                context.Employees.Add(emp4);
                context.SaveChanges();
            }

            if (!context.Contracts.Any())
            {
                Contract ct1 = new Contract
                {
                    Amount = 50000,
                    EmployeeId = 1,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(2)
                };

                Contract ct2 = new Contract
                {
                    Amount = 45000,
                    EmployeeId = 1,
                    StartDate = DateTime.Now.AddYears(-3),
                    EndDate = DateTime.Now
                };
                Contract ct3 = new Contract
                {
                    Amount = 45000,
                    EmployeeId = 1,
                    StartDate = DateTime.Now.AddYears(-3),
                    EndDate = DateTime.Now
                };
                Contract ct4 = new Contract
                {
                    Amount = 45000,
                    EmployeeId = 2,
                    StartDate = DateTime.Now.AddYears(-3),
                    EndDate = DateTime.Now
                };
                Contract ct5 = new Contract
                {
                    Amount = 45000,
                    EmployeeId = 3,
                    StartDate = DateTime.Now.AddYears(-3),
                    EndDate = DateTime.Now
                };

                context.Contracts.Add(ct1);
                context.Contracts.Add(ct2);
                context.Contracts.Add(ct3);
                context.Contracts.Add(ct4);
                context.Contracts.Add(ct5);

                context.SaveChanges();
            }

            

        }
    }
}
