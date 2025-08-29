using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain;
using ProjectManagementSystem.Domain.Master;
using ProjectManagementSystem.Helpers;

namespace ProjectManagementSystem.Features.Masters.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly PmsContext _dbContext;
        public RoleRepository(PmsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(string message, bool isSuccess, Role model)> CreateRole(Role model, CancellationToken cancellationToken = default)
        {
            var roleModels = await _dbContext.Roles.Where(x => x.Name.Trim().ToLower() == model.Name.Trim().ToLower()
                        && x.Code.Trim().ToLower() == model.Code.Trim().ToLower()).ToListAsync();

            if (roleModels.Any())
            {
                return MessageHelper.GetDuplicateMessage<Role>(roleModels.First(), "Name", "Code");
            }

            var entityModel = _dbContext.Roles.Add(model);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return MessageHelper.GetSuccessErrorMessage<Role>(true, entityModel.Entity, MessageTypeEnum.Created);
        }

        public async Task<(string message, bool isSuccess, Role model)> DeleteRole(int roleId, CancellationToken cancellationToken = default)
        {
            var deleteModel = await _dbContext.Roles.FindAsync(roleId);

            if (deleteModel is null)
            {
                return MessageHelper.GetSuccessErrorMessage(false, new Role(), MessageTypeEnum.Deleted);
            }

            deleteModel.IsDeleted = true;
            deleteModel.UpdatedDate = DateTime.Now.Date;

             _dbContext.Roles.Update(deleteModel);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return MessageHelper.GetSuccessErrorMessage(true, deleteModel, MessageTypeEnum.Deleted);
        }

        public async Task<(string message, bool isSuccess, Role model)> GetRoleById(int rolId, CancellationToken cancellationToken = default)
        {
            var roleModel = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == rolId);

            if (roleModel != null)
                return MessageHelper.GetSuccessErrorMessage<Role>(true, roleModel, MessageTypeEnum.Fetched);

            return MessageHelper.GetSuccessErrorMessage<Role>(false, new(), MessageTypeEnum.Fetched);
        }

        public async Task<(string message, bool isSuccess, IEnumerable<Role> models)> GetRoles(CancellationToken cancellationToken = default)
        {
            var roleModels = await _dbContext.Roles.Where(x => x.IsDeleted == false).ToListAsync();

            return MessageHelper.GetSuccessErrorMessage(true, roleModels, MessageTypeEnum.Fetched);
        }

        public async Task<(string message, bool isSuccess, Role model)> UpdateRole(Role model, CancellationToken cancellationToken = default)
        {
            model.UpdatedDate= DateTime.Now;

            _dbContext.Update(model);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return MessageHelper.GetSuccessErrorMessage(true, new Role(), MessageTypeEnum.Updated);
        }
    }
}
