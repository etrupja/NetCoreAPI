using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageEmployees.Models.Entities
{
    public class Contract : IEntityBase
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Amount { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
