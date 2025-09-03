using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementSystem.Features.Masters.Controllers
{
    public class MasterController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Features/Masters/Views/Master.cshtml");
        }
    }
}
