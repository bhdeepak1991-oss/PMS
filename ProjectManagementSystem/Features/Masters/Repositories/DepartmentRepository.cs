using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain;
using ProjectManagementSystem.Domain.Master;
using ProjectManagementSystem.Helpers;

namespace ProjectManagementSystem.Features.Masters.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly PmsContext _dbContext;
        public DepartmentRepository(PmsContext pmsContext)
        {
            _dbContext = pmsContext;
        }
        public async Task<ResponseHelper<Department>> CreateDepartment(Department model, CancellationToken cancellationToken)
        {
            var response = await _dbContext.Departments.AddAsync(model);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new ResponseHelper<Department>(response.Entity, "Department created successfully", true);
        }

        public async Task<ResponseHelper<Department>> DeleteDepartment(int deptId, CancellationToken cancellationToken)
        {
            var dbModel = await _dbContext.Departments.FindAsync(deptId);

            if (dbModel is null)
            {
                return new ResponseHelper<Department>(new(), $"Department with Id {deptId} not found !", false);
            }

            dbModel.IsDeleted = true;
            dbModel.UpdatedDate = DateTime.UtcNow;

            var response = _dbContext.Departments.Update(dbModel);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseHelper<Department>(response.Entity, "Department deleted successfully !", true);
        }

        public async Task<ResponseHelper<Department>> GetDepartmentById(int deptId, CancellationToken cancellationToken)
        {
            var response = await _dbContext.Departments.FindAsync(deptId);

            if (response is null)
            {
                return new ResponseHelper<Department>(new(), $"Department with Id {deptId} not found !", false);
            }

            return new ResponseHelper<Department>(response, "Data fetched successfully", true);
            
        }

        public async Task<ResponseHelper<IEnumerable<Department>>> GetDepartmentList(CancellationToken cancellationToken)
        {
            var response = await _dbContext.Departments.Where(x => x.IsDeleted == false).OrderBy(x=>x.Id).ToListAsync();
            return new ResponseHelper<IEnumerable<Department>>(response, "Data fetched Successfully", true);
        }

        public async  Task<ResponseHelper<Department>> UpdateDepartment(Department model, CancellationToken cancellationToken)
        {
            var updateResponse =  _dbContext.Departments.Update(model);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseHelper<Department>(updateResponse.Entity, "Department updated successfully", true);
        }
    }
}
