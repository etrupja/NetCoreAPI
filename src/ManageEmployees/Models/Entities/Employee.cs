using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ManageEmployees.Models.Enums;

namespace ManageEmployees.Models.Entities
{
    public class Employee : IEntityBase
    {
        public Employee()
        {
            Contracts = new List<Contract>();
        }

        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(120)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(120)]
        public string FirstName { get; set; }

        [Required]
        public int Age { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]
        public JobPosition JobPosition { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
