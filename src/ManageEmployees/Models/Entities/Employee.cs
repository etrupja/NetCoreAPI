using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageEmployees.Models.Enums;

namespace ManageEmployees.Models.Entities
{
    public class Employee : IEntityBase
    {
        public Employee()
        {
            Contracts = new List<Contract>();
        }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public JobPosition JobPosition { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
