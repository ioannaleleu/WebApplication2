using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication2.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Display(Name = "Department Name")]
        [Required, StringLength(100, MinimumLength = 2)]
        public string? DepartmentName { get; set; }
        public ICollection<EmployeeDepartment>? EmployeeDepartments { get; set; }
    }
}

