using System;
using System.ComponentModel.DataAnnotations;

namespace ExamAzure.Dto
{
    public class AddEmployee
    {
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string EmployeeName { get; set; }

        [Required]
        [DataType(DataType.Date)]
 
        public DateTime EmployeeDOB { get; set; }

        [Required]
        public string EmployeeDepartment { get; set; }
    }
}
