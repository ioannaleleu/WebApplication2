namespace WebApplication2.Models
{
    public class EmployeeDepartment
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

    }
}
