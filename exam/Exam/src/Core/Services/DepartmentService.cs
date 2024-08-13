using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.Core.DTOs;
using Exam.Core.Entities;
using Exam.Core.Interfaces;
using Exam.src.Core.DTOs;
using Exam.src.Core.Interfaces;

namespace Exam.Core.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            return departments.Select(d => new DepartmentDto
            {
                Id = d.Id,
                DepartmentName = d.DepartmentName,
                DepartmentCode = d.DepartmentCode,
                Location = d.Location,
                NumberOfPersonals = d.NumberOfPersonals
            });
        }

        // Other methods for Add, Update, Delete
    }
}
