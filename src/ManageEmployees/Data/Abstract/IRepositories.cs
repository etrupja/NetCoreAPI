using ManageEmployees.Models.Entities;

namespace ManageEmployees.Data.Abstract
{
    public interface IEmployeeRepository : IEntityBaseRepository<Employee> { }

    public interface IContractRepository : IEntityBaseRepository<Contract> { }

    public interface IDepartmentRepository : IEntityBaseRepository<Department> { }
}
