using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;

namespace WebApplication2.Pages.JobTitles
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public IndexModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public IList<JobTitle> JobTitle { get;set; } = default!;

        public JobTitleIndexData JobTitlesData { get; set; }
        public int JobTitleID { get; set; }
        public int EmployeeID { get; set; }
        public async Task OnGetAsync(int? id, int? employeeID)
        {
            JobTitlesData = new JobTitleIndexData();
            JobTitlesData.JobTitles = await _context.JobTitle.Include(i => i.Employees).OrderBy(i => i.JobTitleName).ToListAsync();
            if (id != null)
            {
                JobTitleID = id.Value;
                JobTitle jobTitle = JobTitlesData.JobTitles
                .Where(i => i.ID == id.Value).Single();
                JobTitlesData.Employees = jobTitle.Employees;
            }
        }
    }
}
