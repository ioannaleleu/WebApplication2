using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;

namespace WebApplication2.Models
{
    public class EmployeeDepartmentsPageModel : PageModel
    {
        public List<AssignedDepartmentData> AssignedDepartmentDataList;
       
        
       
        public void PopulateAssignedDepartmentData(WebApplication2Context context, Employee employee)
        {
            var allDepartments = context.Department;
            var employeeDepartments = new HashSet<int>(
                employee.EmployeeDepartments.Select(c => c.DepartmentID));//
            AssignedDepartmentDataList = new List<AssignedDepartmentData>();

            foreach (var cat in allDepartments)
            {
                AssignedDepartmentDataList.Add(new AssignedDepartmentData
                {
                    DepartmentID = cat.ID,
                    Name = cat.DepartmentName,
                    Assigned = employeeDepartments.Contains(cat.ID)
                });
            }
        }
        public void UpdateEmployeeDepartments(WebApplication2Context context, string[] selectedDepartments, Employee employeeToUpdate)
    {
        if (selectedDepartments == null)
        {
           employeeToUpdate.EmployeeDepartments = new List<EmployeeDepartment>();
            return;
        }

        var selectedDepartmentss = new HashSet<string>(selectedDepartments);
            var employeeDepartments = new HashSet<int>
                (employeeToUpdate.EmployeeDepartments.Select(c => c.DepartmentID));
            
            foreach (var cat in context.Department)
        {
                if (selectedDepartmentss.Contains(cat.ID.ToString()))
                {
                    if (!employeeDepartments.Contains(cat.ID))
                    {
                        employeeToUpdate.EmployeeDepartments.Add(
                        new EmployeeDepartment
                        {
                            EmployeeID = employeeToUpdate.ID,
                            DepartmentID = cat.ID
                        });
                    }
                }
                else
                {
                    if (employeeDepartments.Contains(cat.ID))
                    {
                        EmployeeDepartment courseToRemove = employeeToUpdate
                            .EmployeeDepartments
                            .SingleOrDefault(i => i.DepartmentID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

