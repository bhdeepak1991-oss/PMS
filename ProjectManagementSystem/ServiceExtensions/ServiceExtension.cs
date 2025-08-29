using ProjectManagementSystem.Features.Masters.Repositories;

namespace ProjectManagementSystem.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            #region Repository Extension

            services.AddScoped<IRoleRepository, RoleRepository>();

            #endregion

            return services;

        }
    }
}
