using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication2.Models
{
    public class JobTitle
    {
        public int ID { get; set; }
        [Display(Name = "Job Title")]
        [Required, StringLength(100, MinimumLength = 2)]
        public string? JobTitleName { get; set; }
        [Display(Name = "Job Description")]
        [StringLength(200, MinimumLength = 5)]

        public string? Description { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
