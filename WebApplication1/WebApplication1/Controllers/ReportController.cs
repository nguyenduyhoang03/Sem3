using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Statistics()
        {
            var stats = _context.Employees
                .GroupBy(e => e.Department.DepartmentName)
                .Select(g => new
                {
                    DepartmentName = g.Key,
                    EmployeeCount = g.Count()
                })
                .ToList();

            return View(stats);
        }
    }
}
