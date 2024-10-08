using ExamAzure.Dto;
using ExamAzure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public EmployeesController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.Include(e => e.ProjectEmployees).ToListAsync();
        }

        // POST: api/employees
        [HttpPost]
        public IActionResult AddEmployee([FromBody] AddEmployee dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Kiểm tra tuổi
            if ((DateTime.Now.Year - dto.EmployeeDOB.Year) < 16)
            {
                ModelState.AddModelError("EmployeeDOB", "Nhân viên phải trên 16 tuổi.");
                return BadRequest(ModelState);
            }

            var employee = new Employee
            {
                EmployeeName = dto.EmployeeName,
                EmployeeDOB = dto.EmployeeDOB,
                EmployeeDepartment = dto.EmployeeDepartment
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return CreatedAtAction(nameof(AddEmployee), new { id = employee.EmployeeId }, employee);
        }

    }
}