using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ManageEmployees.Models.Enums;
using Newtonsoft.Json;

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
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(120)]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [Required]
        [JsonProperty("jobPosition")]
        public JobPosition JobPosition { get; set; }

        public RecordStatus RecordStatus { get; set; }

        [ForeignKey("Department")]
        [JsonProperty("departmentId")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }

    public class EmployeeViewModel
    {
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }
        [JsonProperty("jobPosition")]
        public JobPosition JobPosition { get; set; }
        [JsonProperty("departmentId")]
        public int DepartmentId { get; set; }

    }
}
