namespace WebApplication2.Models
{
    public class EmployeeData
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
