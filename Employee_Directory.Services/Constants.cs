namespace Employee_Directory.Services
{
    public static class Constants
    {
        public static class Employee
        {
            public const string GetEmployees = "Select e.Id, e.FirstName, e.LastName, e. PreferredName, e.Email, d.Name as Department, j.Name as JobTitle, o.Name as Office, e.JobTitleId, e.DepartmentId, e.OfficeId, e.PhoneNumber, e.SkypeId from Employees e left join Departments d on e.DepartmentId = d.Id left join JobTitles j on e.JobTitleId = j.Id left join Offices o on e.OfficeId = o.Id";

            public const string GetEmployee = "Select e.Id, e.FirstName, e.LastName, e. PreferredName, e.Email, d.Name as Department, j.Name as JobTitle, o.Name as Office, e.JobTitleId, e.DepartmentId, e.OfficeId, e.PhoneNumber, e.SkypeId from Employees e left join Departments d on e.DepartmentId = d.Id left join JobTitles j on e.JobTitleId = j.Id left join Offices o on e.OfficeId = o.Id WHERE e.Id=@0";

            public const string TableName = "Employees";

            public const string PrimaryKeyName = "Id";
        }

        public static class Department
        {
            public const string GetDepartments = "Select * from Departments";

            public const string GetDepartment = "SELECT * FROM Departments WHERE Id=@0";

            public const string TableName = "Departments";

            public const string PrimaryKeyName = "Id";
        }

        public static class Office
        {
            public const string GetOffices = "Select * from Offices";

            public const string GetOffice = "SELECT * FROM Offices WHERE Id=@0";

            public const string TableName = "Offices";

            public const string PrimaryKeyName = "Id";
        }

        public static class JobTitle
        {
            public const string GetJobTitles = "Select * from JobTitles";

            public const string GetJobTitle = "SELECT * FROM JobTitles WHERE Id=@0";

            public const string TableName = "JobTitles";

            public const string PrimaryKeyName = "Id";
        }
    }
 }
