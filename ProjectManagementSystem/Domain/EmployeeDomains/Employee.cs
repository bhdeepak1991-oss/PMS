namespace ProjectManagementSystem.Domain.EmployeeDomains
{
    public class Employee : BaseDomain
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmpCode { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public string Gender { get; set; }
        public string EmpStatus { get; set; }
    }
}
