using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        [Required]
        [StringLength(10)]
        public string DepartmentCode { get; set; }

        public string Location { get; set; }

        public int NumberOfPersonals { get; set; }
    }
}
