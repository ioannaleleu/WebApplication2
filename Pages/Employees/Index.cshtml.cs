using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;


namespace WebApplication2.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public IndexModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }
        public IList<Employee> Employee { get; set; }
        public EmployeeData EmployeeD { get; set; }
        public int EmployeeID { get; set; }
        public int DepartmentID { get; set; }

        public async Task OnGetAsync(int? id, int? departmentID)
        {
            EmployeeD = new EmployeeData();

            EmployeeD.Employees = await _context.Employee
            .Include(b => b.JobTitle)
            .Include(b => b.EmployeeDepartments)
            .ThenInclude (b => b.Department)
            .AsNoTracking()
            .OrderBy(b => b.FirstName)
            .ToListAsync();

            if (id != null)
            {
                EmployeeID = id.Value;
                Employee employee = EmployeeD.Employees
                 .Where(i => i.ID == id.Value).Single();
                EmployeeD.Departments = employee.EmployeeDepartments.Select(s => s.Department);
            }
        }





    }
}
