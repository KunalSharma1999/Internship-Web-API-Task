using Employee_Directory.Contracts;
using Employee_Directory.Models;
using System;
using System.Collections.Generic;

namespace Employee_Directory.Services
{
    public class DepartmentServices: IDepartmentServices
    {
        private readonly PetaPoco.Database db = new PetaPoco.Database("Data Source=localhost;Initial Catalog=EmployeeDB;Integrated Security=True", "System.Data.SqlClient");

        public IEnumerable<Department> GetDepartments()
        {
            try
            {
                return db.Query<Department>(Constants.Department.GetDepartments);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(Department department)
        {
            try
            {
                if(department != null)
                {
                    if(department.Id != default(int))
                    {
                        db.Update(Constants.Department.TableName, Constants.Department.PrimaryKeyName , department);
                    }
                    else
                    {
                        db.Insert(Constants.Department.TableName, department);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public Department GetDepartment(int id)
        {
            try
            {
                return db.SingleOrDefault<Department>(Constants.Department.GetDepartment, id);
            }
            catch
            {
                throw;
            }
        }
    }
}
