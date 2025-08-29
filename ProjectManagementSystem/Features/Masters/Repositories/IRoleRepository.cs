using ProjectManagementSystem.Domain.Master;

namespace ProjectManagementSystem.Features.Masters.Repositories
{
    public interface IRoleRepository
    {
        Task<(string message, bool isSuccess, Role model)> CreateRole(Role model, CancellationToken cancellationToken=default);
        Task<(string message, bool isSuccess, Role model)> DeleteRole(int roleId, CancellationToken cancellationToken=default);
        Task<(string message, bool isSuccess, Role model)> UpdateRole(Role model, CancellationToken cancellationToken = default);
        Task<(string message, bool isSuccess, IEnumerable<Role> models)> GetRoles(CancellationToken cancellationToken = default);
        Task<(string message, bool isSuccess, Role model)> GetRoleById(int rolId, CancellationToken cancellationToken = default);
    }
}
