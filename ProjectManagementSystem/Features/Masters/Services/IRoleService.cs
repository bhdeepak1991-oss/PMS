using ProjectManagementSystem.Domain.Master;
using ProjectManagementSystem.Helpers;

namespace ProjectManagementSystem.Features.Masters.Services
{
    public interface IRoleService
    {
        Task<ResponseHelper<Role>> GetRoleDetailById(int roleId, CancellationToken cancellationToken);
        Task<ResponseHelper<IEnumerable<Role>>> GetRoleDetail(CancellationToken cancellationToken);
        Task<ResponseHelper<Role>> CreateRole(Role model, CancellationToken cancellationToken);
        Task<ResponseHelper<Role>> UpdateRole(Role model, CancellationToken cancellationToken);
        Task<ResponseHelper<Role>> DeleteRole(int roleId, CancellationToken cancellationToken);

    }
}
