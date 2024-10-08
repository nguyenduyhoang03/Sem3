using System;
using System.ComponentModel.DataAnnotations;

namespace ExamAzure.Dto
{
    public class UpdateEmployee
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee name is required.")]
        [MaxLength(100, ErrorMessage = "Employee name cannot exceed 100 characters.")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Employee date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime EmployeeDOB { get; set; }

        [Required(ErrorMessage = "Employee department is required.")]
        [MaxLength(50, ErrorMessage = "Department name cannot exceed 50 characters.")]
        public string EmployeeDepartment { get; set; }
    }
}
