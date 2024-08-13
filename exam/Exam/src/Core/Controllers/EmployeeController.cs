using System.Threading.Tasks;
using Exam.Core.Interfaces;
using Exam.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exam.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return View(employees);
        }

        // Actions for Create, Edit, Delete
    }
}
