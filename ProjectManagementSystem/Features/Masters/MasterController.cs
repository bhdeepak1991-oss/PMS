using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementSystem.Features.Masters
{
    public class MasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
