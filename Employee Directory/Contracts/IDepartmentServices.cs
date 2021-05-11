using Employee_Directory.Models;
using System.Collections.Generic;

namespace Employee_Directory.Contracts
{
    public interface IDepartmentServices
    {
        IEnumerable<Department> GetAllDepartments();
        void AddDepartment(Department department);
        void UpdateDepartment(int id, Department department);
        Department GetDepartmentById(int id);
    }
}
