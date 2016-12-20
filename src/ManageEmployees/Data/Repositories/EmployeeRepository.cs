using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageEmployees.Data.Abstract;
using ManageEmployees.Data.Base;
using ManageEmployees.Models.Entities;

namespace ManageEmployees.Data.Repositories
{
    public class EmployeeRepository : EntityBaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ManageEmployeesContext context) : base(context) { }
    }
}
