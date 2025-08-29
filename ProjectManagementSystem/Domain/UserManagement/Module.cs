namespace ProjectManagementSystem.Domain.UserManagement
{
    public class Module : BaseDomain
    {
        public string ModuleName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string IconClass { get; set; }
        public int DisplayOrder { get; set; }
    }
}
