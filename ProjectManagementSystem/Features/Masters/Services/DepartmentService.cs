using ProjectManagementSystem.Domain.Master;
using ProjectManagementSystem.Features.Masters.Repositories;
using ProjectManagementSystem.Helpers;

namespace ProjectManagementSystem.Features.Masters.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<ResponseHelper<Department>> CreateDepartment(Department model, CancellationToken cancellationToken)
                    => await _departmentRepository.CreateDepartment(model, cancellationToken);


        public async Task<ResponseHelper<Department>> DeleteDepartment(int deptId, CancellationToken cancellationToken)
                => await _departmentRepository.DeleteDepartment(deptId, cancellationToken);


        public async Task<ResponseHelper<Department>> GetDepartmentById(int deptId, CancellationToken cancellationToken)
              => await _departmentRepository.GetDepartmentById(deptId, cancellationToken);

        public async Task<ResponseHelper<IEnumerable<Department>>> GetDepartmentList(CancellationToken cancellationToken)
                => await _departmentRepository.GetDepartmentList(cancellationToken);

        public async Task<ResponseHelper<Department>> UpdateDepartment(Department model, CancellationToken cancellationToken)
          => await _departmentRepository.UpdateDepartment(model, cancellationToken);
    }
}
