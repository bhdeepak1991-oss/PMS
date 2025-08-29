using System.Security.Principal;

namespace ProjectManagementSystem.Domain
{
    public abstract class BaseDomain
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public int CreatedBy { get; set; } = 1;// for admin
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
