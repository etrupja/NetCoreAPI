using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageEmployees.Models.Entities
{
    public class Department : IEntityBase
    {
        public Department()
        {
            Employees = new List<Employee>();
        }

        [Key,Column(Order = 0)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        [StringLength(120)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Department description is required.")]
        public string Description { get; set; }


        public ICollection<Employee> Employees { get; set; }
    }
}
