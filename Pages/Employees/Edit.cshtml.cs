using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.Employees
{
    public class EditModel : EmployeeDepartmentsPageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public EditModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee = await _context.Employee
                .Include(e => e.JobTitle)
                .Include(e => e.EmployeeDepartments).ThenInclude(e => e.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);



            if (Employee == null)
            {
                return NotFound();
            }
            
            PopulateAssignedDepartmentData(_context, Employee);

            ViewData["JobTitleID"] = new SelectList(_context.JobTitle, "ID", "JobTitleName");
            return Page();
        }

  
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedDepartments)
        {
            
                if (id == null)
                {
                    return NotFound();
                }
                var employeeToUpdate = await _context.Employee
                .Include(i => i.JobTitle)
                .Include(i => i.EmployeeDepartments)
                .ThenInclude(i => i.Department)
                .FirstOrDefaultAsync(s => s.ID == id);

                if (employeeToUpdate == null)
                {
                    return NotFound();
                }

                if (await TryUpdateModelAsync<Employee>(
                    employeeToUpdate, 
                    "Employee", 
                    i => i.FirstName, i => i.LastName, 
                    i => i.DateOfBirth, i => i.HireDate, 
                    i => i.JobTitle))
                {

                UpdateEmployeeDepartments(_context, selectedDepartments, employeeToUpdate);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }

            UpdateEmployeeDepartments(_context, selectedDepartments, employeeToUpdate);
            PopulateAssignedDepartmentData(_context, employeeToUpdate);
            return Page();
            }
        }
    }


                