using Microsoft.AspNetCore.Mvc;

namespace Exam3.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
