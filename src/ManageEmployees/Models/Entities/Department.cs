using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageEmployees.Models.Entities
{
    public class Department : IEntityBase
    {
        public Department()
        {
            Employees = new List<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
