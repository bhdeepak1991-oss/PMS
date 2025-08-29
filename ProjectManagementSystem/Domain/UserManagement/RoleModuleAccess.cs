using ProjectManagementSystem.Domain.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementSystem.Domain.UserManagement
{
    public class RoleModuleAccess : BaseDomain
    {
        public int RoleId { get; set; }
        public int ModuleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Roles { get; set; }

        [ForeignKey("ModuleId")]
        public virtual Module Modules { get; set; }
    }
}
