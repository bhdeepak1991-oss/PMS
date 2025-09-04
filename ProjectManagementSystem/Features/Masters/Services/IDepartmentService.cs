using ProjectManagementSystem.Domain.Master;
using ProjectManagementSystem.Helpers;

namespace ProjectManagementSystem.Features.Masters.Services
{
    public interface IDepartmentService
    {
        Task<ResponseHelper<IEnumerable<Department>>> GetDepartmentList(CancellationToken cancellationToken);
        Task<ResponseHelper<Department>> GetDepartmentById(int deptId, CancellationToken cancellationToken);
        Task<ResponseHelper<Department>> CreateDepartment(Department model, CancellationToken cancellationToken);
        Task<ResponseHelper<Department>> UpdateDepartment(Department model, CancellationToken cancellationToken);
        Task<ResponseHelper<Department>> DeleteDepartment(int deptId, CancellationToken cancellationToken);
    }
}
