using Employee_Directory.Contracts;
using Employee_Directory.Models;
using System;
using System.Collections.Generic;

namespace Employee_Directory.Services
{
    public class DepartmentServices: IDepartmentServices
    {
        PetaPoco.Database db = new PetaPoco.Database("Data Source=localhost;Initial Catalog=EmployeeDB;Integrated Security=True", "System.Data.SqlClient");


        public IEnumerable<Department> GetAllDepartments()
        {
            try
            {
                return db.Query<Department>("Select * from Departments");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddDepartment(Department department)
        {
            try
            {
                db.Insert("Departments", department);
            }
            catch
            {
                throw;
            }
        }

        public void UpdateDepartment(int id, Department department)
        { 
            try
            {
                department.Id = id;
                db.Update("Departments", "Id", department);
            }
            catch
            {
                throw;
            }
        }

        public Department GetDepartmentById(int id)
        {
            try
            {
                return db.SingleOrDefault<Department>("SELECT * FROM Departments WHERE Id=@0", id);
            }
            catch
            {
                throw;
            }
        }
    }
}
