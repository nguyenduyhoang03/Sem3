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
        [Range(16, int.MaxValue, ErrorMessage = "Nhân viên phải trên 16 tuổi.")]
        public DateTime EmployeeDOB { get; set; }

        [Required]
        public string EmployeeDepartment { get; set; }
    }
}
