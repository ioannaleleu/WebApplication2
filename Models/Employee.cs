using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication2.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "First name needs to start with capital letter'"), Required, StringLength(100, MinimumLength = 3)]

        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Last name needs to start with capital letter'"), Required, StringLength(100, MinimumLength = 3)]

        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        public int JobTitleID { get; set; }
        public JobTitle? JobTitle { get; set; }
        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }

    }
}
