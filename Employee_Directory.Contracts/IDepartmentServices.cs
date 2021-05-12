using Employee_Directory.Models;
using System.Collections.Generic;

namespace Employee_Directory.Contracts
{
    public interface IDepartmentServices
    {
        IEnumerable<Department> GetDepartments();

        void Add(Department department);

        Department GetDepartment(int id);
    }
}
