using Microsoft.AspNetCore.Mvc;

namespace Exam3.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
