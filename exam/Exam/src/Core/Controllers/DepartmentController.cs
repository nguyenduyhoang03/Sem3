using System.Threading.Tasks;
using Exam.Core.Interfaces;
using Exam.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exam.WebUI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return View(departments);
        }

        // Actions for Create, Edit, Delete
    }
}
