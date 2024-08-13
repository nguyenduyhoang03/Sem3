using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.Core.DTOs;
using Exam.src.Core.Entities;
using Exam.src.Core.Interfaces;

namespace Exam.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                EmployeeName = e.EmployeeName,
                EmployeeCode = e.EmployeeCode,
                DepartmentId = e.DepartmentId,
                Rank = e.Rank,
                DepartmentName = e.Department.DepartmentName
            });
        }

        // Other methods for Add, Update, Delete
    }
}
