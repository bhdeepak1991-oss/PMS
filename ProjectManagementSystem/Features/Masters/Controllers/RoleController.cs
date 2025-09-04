using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Domain.Master;
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

        public async Task<IActionResult> Index(int id)
        {
            if (id != 0)
            {
                var response = await _roleService.GetRoleDetailById(id, default);
                return await Task.Run(() => View("~/Features/Masters/Views/RoleCreate.cshtml", response.Model));
            }
            return await Task.Run(() => View("~/Features/Masters/Views/RoleCreate.cshtml", new Role()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(Role model)
        {
            if (model.Id != 0)
            {
                var updateResponse = await _roleService.UpdateRole(model, default);
                return Json(updateResponse);
            }
            var response = await _roleService.CreateRole(model, default);
            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoleList()
        {
            var response = await _roleService.GetRoleDetail(default);
            return PartialView("~/Features/Masters/Views/RoleList.cshtml", response.Model);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            var response = await _roleService.DeleteRole(roleId, default);
            return Json(response);
        }

    }
}
