namespace EmployeeDirectory.Services
{
    public static class Constants
    {
        public static class Employee
        {
            public const string GetEmployees = "Select e.Id, e. PreferredName, d.Name as Department, j.Name as JobTitle, o.Name as Office from Employees e left join Departments d on e.DepartmentId = d.Id left join JobTitles j on e.JobTitleId = j.Id left join Offices o on e.OfficeId = o.Id";
        }
    }
 }
