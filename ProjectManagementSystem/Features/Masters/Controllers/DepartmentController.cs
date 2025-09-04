using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementSystem.Features.Masters.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
