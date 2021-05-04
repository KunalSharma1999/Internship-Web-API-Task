using Employee_Directory.Models;
using System;
using System.Collections.Generic;

namespace Employee_Directory.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        PetaPoco.Database db = new PetaPoco.Database("Data Source=localhost;Initial Catalog=EmployeeDB;Integrated Security=True", "System.Data.SqlClient");


        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return db.Query<Employee>("Select * from Employees");
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
                return db.SingleOrDefault<Employee>("SELECT * FROM Employees WHERE Id=@0", id);
            }
            catch
            {
                throw;
            }
        }
    }
}
