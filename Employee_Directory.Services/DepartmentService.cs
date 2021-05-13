using Employee_Directory.Contracts;
using Employee_Directory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Directory.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly PetaPoco.Database db;

        public DepartmentService(PetaPoco.Database database)
        {
            this.db = database;
        }

        public IEnumerable<Department> Get()
        {
            return db.Query<Department>(Constants.Department.GetDepartments);
        }

        public async Task<Department> Get(int id)
        {
             return await db.SingleAsync<Department>(id);
        }

        public async Task<object> Add(Department department)
        {
            return await db.InsertAsync(department);
        }

        public async Task<int> Update(Department department)
        {
            return await db.UpdateAsync(department);
        }
    }
}
