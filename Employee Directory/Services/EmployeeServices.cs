using Employee_Directory.Contracts;
using Employee_Directory.Models;
using System;
using System.Collections.Generic;

namespace Employee_Directory.Services
{
    public class EmployeeServices: IEmployeeServices
    {
        PetaPoco.Database db = new PetaPoco.Database("Data Source=localhost;Initial Catalog=EmployeeDB;Integrated Security=True", "System.Data.SqlClient");


        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return db.Query<Employee>("Select e.Id, e.FirstName, e.LastName, e. PreferredName, e.Email, d.Name as Department, j.Name as JobTitle, o.Name as Office, e.JobTitleId, e.DepartmentId, e.OfficeId, e.PhoneNumber, e.SkypeId from Employees e left join Departments d on e.DepartmentId = d.Id left join JobTitles j on e.JobTitleId = j.Id left join Offices o on e.OfficeId = o.Id");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                db.Insert("Employees", employee);
            }
            catch
            {
                throw;
            }
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            try
            {
                employee.Id = id;
                db.Update("Employees", "ID", employee);
            }
            catch
            {
                throw;
            }
        }

        public Employee GetEmployeeData(int id)
        {
            try
            {
                return db.SingleOrDefault<Employee>("Select e.Id, e.FirstName, e.LastName, e. PreferredName, e.Email, d.Name as Department, j.Name as JobTitle, o.Name as Office, e.JobTitleId, e.DepartmentId, e.OfficeId, e.PhoneNumber, e.SkypeId from Employees e left join Departments d on e.DepartmentId = d.Id left join JobTitles j on e.JobTitleId = j.Id left join Offices o on e.OfficeId = o.Id WHERE e.Id=@0", id);
            }
            catch
            {
                throw;
            }
        }
    }
}
