using System.Security.Policy;
using WebApplication2.Models;

namespace WebApplication2.Models.ViewModels
{
    public class JobTitleIndexData
    {
        public IEnumerable<JobTitle> JobTitles { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
