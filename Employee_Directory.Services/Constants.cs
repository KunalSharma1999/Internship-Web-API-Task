namespace Employee_Directory.Services
{
    public static class Constants
    {
        public static class Employee
        {
            public const string GetEmployees = "Select e.Id as id, e. PreferredName as preferredName, d.Name as department, j.Name as jobTitle, o.Name as office from Employees e left join Departments d on e.DepartmentId = d.Id left join JobTitles j on e.JobTitleId = j.Id left join Offices o on e.OfficeId = o.Id";
        }

        public static class Department
        {
            public const string GetDepartments = "Select * from Departments";
        }

        public static class Office
        {
            public const string GetOffices = "Select * from Offices";
        }

        public static class JobTitle
        {
            public const string GetJobTitles = "Select * from JobTitles";
        }
    }
 }
