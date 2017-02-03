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
                Department dpt1 = new Department { Name = "Development", Description= "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do tempor incididunt ut labore et dolore magna aliqua. This is supporting text.", RecordStatus = RecordStatus.Active };
                Department dpt2 = new Department { Name = "Marketing", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do tempor incididunt ut labore et dolore magna aliqua. This is supporting text.", RecordStatus = RecordStatus.Active };
                Department dpt3 = new Department { Name = "Consulting", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do tempor incididunt ut labore et dolore magna aliqua. This is supporting text.",RecordStatus = RecordStatus.Active };

                context.Departments.Add(dpt1); //id=1
                context.Departments.Add(dpt2); //id=2
                context.Departments.Add(dpt3); //id=3

                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                Employee emp1 = new Employee
                {
                    FirstName = "Adam",
                    LastName = "Abraham",
                    BirthDate = DateTime.Now.Date.AddYears(-24),
                    DepartmentId = 1,
                    JobPosition = JobPosition.Junior,
                    RecordStatus = RecordStatus.Active 
                };
                Employee emp2 = new Employee
                {
                    FirstName = "Alexandra",
                    LastName = "Allan",
                    BirthDate = DateTime.Now.Date.AddYears(-23),
                    DepartmentId = 1,
                    JobPosition = JobPosition.Senior,
                    RecordStatus = RecordStatus.Active
                };
                Employee emp3 = new Employee
                {
                    FirstName = "Bella",
                    LastName = "Chapman",
                    BirthDate = DateTime.Now.Date.AddYears(-20),
                    DepartmentId = 2,
                    JobPosition = JobPosition.Trainee,
                    RecordStatus = RecordStatus.Active
                };
                Employee emp4 = new Employee
                {
                    FirstName = "Frank",
                    LastName = "Clark",
                    BirthDate = DateTime.Now.Date.AddYears(-30),
                    DepartmentId = 3,
                    JobPosition = JobPosition.Senior,
                    RecordStatus = RecordStatus.Active
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
                    Name="Contract ct1",
                    Amount = 50000,
                    EmployeeId = 1,
                    StartDate = DateTime.Now.Date,
                    EndDate = DateTime.Now.Date.AddYears(2),
                    RecordStatus = RecordStatus.Active
                };

                Contract ct2 = new Contract
                {
                    Name = "Contract ct2",
                    Amount = 45000,
                    EmployeeId = 1,
                    StartDate = DateTime.Now.Date.AddYears(-3),
                    EndDate = DateTime.Now.Date,
                    RecordStatus = RecordStatus.Active
                };
                Contract ct3 = new Contract
                {
                    Name = "Contract ct3",
                    Amount = 45000,
                    EmployeeId = 1,
                    StartDate = DateTime.Now.Date.AddYears(-3),
                    EndDate = DateTime.Now.Date,
                    RecordStatus = RecordStatus.Active
                };
                Contract ct4 = new Contract
                {
                    Name = "Contract ct4",
                    Amount = 45000,
                    EmployeeId = 2,
                    StartDate = DateTime.Now.Date.AddYears(-3),
                    EndDate = DateTime.Now.Date,
                    RecordStatus = RecordStatus.Active
                };
                Contract ct5 = new Contract
                {
                    Name = "Contract ct5",
                    Amount = 45000,
                    EmployeeId = 3,
                    StartDate = DateTime.Now.Date.AddYears(-3),
                    EndDate = DateTime.Now.Date,
                    RecordStatus = RecordStatus.Active
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
