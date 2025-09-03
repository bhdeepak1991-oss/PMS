using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Features.Masters.Services;

namespace ProjectManagementSystem.Features.Masters.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _roleService.GetRoleDetail(default);
            return View("~/Features/Masters/Views/RoleList.cshtml", response);
        }
    }
}
