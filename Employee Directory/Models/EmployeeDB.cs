using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Employee_Directory.Models
{
    public class EmployeeDB
    {
        public IEnumerable<Employee> GetEmployees()
        {
            var databaseContext = new PetaPoco.Database("Data Source=localhost;Initial Catalog=EmployeeDB;Integrated Security=True", ".NET Framework Data Provider for SQL Server");
            return databaseContext.Query<Employee>("Select * from Employees");
        }
    }
}
