using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.Employees
{
    public class CreateModel : EmployeeDepartmentsPageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public CreateModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["JobTitleID"] = new SelectList(_context.Set<JobTitle>(), "ID", "JobTitleName");
            var employee = new Employee();
            employee.EmployeeDepartments = new List<EmployeeDepartment>();
            PopulateAssignedDepartmentData(_context, employee);
            return Page();
        }
        [BindProperty]
        public Employee Employee { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedDepartments)
        {
            var newEmployee = new Employee();
            if (selectedDepartments != null)
            {
                newEmployee.EmployeeDepartments = new List<EmployeeDepartment>();
                foreach (var cat in selectedDepartments)
                {
                    var catToAdd = new EmployeeDepartment
                    {
                        DepartmentID = int.Parse(cat)
                    };
                    newEmployee.EmployeeDepartments.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Employee>(newEmployee, "Employee", i => i.FirstName, i => i.LastName, i => i.DateOfBirth, i => i.HireDate, i => i.JobTitleID))
            {
                _context.Employee.Add(newEmployee);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedDepartmentData(_context, newEmployee);
            return Page();
        }
    }
}

        