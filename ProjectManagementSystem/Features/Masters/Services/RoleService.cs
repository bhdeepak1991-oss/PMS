using ProjectManagementSystem.Domain.Master;
using ProjectManagementSystem.Features.Masters.Repositories;
using ProjectManagementSystem.Helpers;

namespace ProjectManagementSystem.Features.Masters.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ResponseHelper<Role>> CreateRole(Role model, CancellationToken cancellationToken)
        {
            var response= await _roleRepository.CreateRole(model, cancellationToken);
            return new ResponseHelper<Role>(response.model, response.message, response.isSuccess);
        }

        public async  Task<ResponseHelper<Role>> DeleteRole(int roleId, CancellationToken cancellationToken)
        {
            var response = await _roleRepository.DeleteRole(roleId, cancellationToken);
            return new ResponseHelper<Role>(response.model, response.message, response.isSuccess);
        }

        public async Task<ResponseHelper<IEnumerable<Role>>> GetRoleDetail(CancellationToken cancellationToken)
        {
            var response = await _roleRepository.GetRoles(cancellationToken);
            return new ResponseHelper<IEnumerable<Role>>(response.models, response.message, response.isSuccess);
        }

        public async  Task<ResponseHelper<Role>> GetRoleDetailById(int roleId, CancellationToken cancellationToken)
        {
            var response = await _roleRepository.GetRoleById(roleId, cancellationToken);
            return new ResponseHelper<Role>(response.model, response.message, response.isSuccess);
        }

        public async  Task<ResponseHelper<Role>> UpdateRole(Role model, CancellationToken cancellationToken)
        {
            var response = await _roleRepository.UpdateRole(model, cancellationToken);
            return new ResponseHelper<Role>(response.model, response.message, response.isSuccess);
        }
    }
}
