using Exam.Entities;
using System.Collections.Generic;

namespace Exam.src.Core.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public string Location { get; set; }
        public int NumberOfPersonals { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
