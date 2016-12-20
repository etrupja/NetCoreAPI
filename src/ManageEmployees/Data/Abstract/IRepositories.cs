using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageEmployees.Models.Entities;

namespace ManageEmployees.Data.Abstract
{
    public interface IEmployeeRepository : IEntityBaseRepository<Employee> { }

    public interface IContractRepository : IEntityBaseRepository<Contract> { }

    public interface IDepartmentRepository : IEntityBaseRepository<Department> { }
}
