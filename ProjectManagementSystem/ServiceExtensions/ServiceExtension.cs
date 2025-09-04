using ProjectManagementSystem.Features.Masters.Repositories;
using ProjectManagementSystem.Features.Masters.Services;

namespace ProjectManagementSystem.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            #region Repository Extension

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            #endregion


            #region Service Extension

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            #endregion

            return services;

        }
    }
}
