using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(10)]
        public string EmployeeCode { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        public string Rank { get; set; }
    }
}
