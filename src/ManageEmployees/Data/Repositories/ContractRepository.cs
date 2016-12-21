using ManageEmployees.Data.Abstract;
using ManageEmployees.Data.Base;
using ManageEmployees.Models.Entities;

namespace ManageEmployees.Data.Repositories
{
    public class ContractRepository : EntityBaseRepository<Contract>, IContractRepository
    {
        public ContractRepository(ManageEmployeesContext context) : base(context) { }
    }
}
