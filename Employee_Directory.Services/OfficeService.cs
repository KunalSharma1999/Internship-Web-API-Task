using Employee_Directory.Contracts;
using Employee_Directory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Directory.Services
{
    public class OfficeService: IOfficeService
    {
        private readonly PetaPoco.Database db;

        public OfficeService(PetaPoco.Database database)
        {
            this.db = database;
        }

        public IEnumerable<Office> Get()
        {
            return db.Query<Office>(Constants.Office.GetOffices);
        }

        public async Task<Office> Get(int id)
        {
            return await db.SingleAsync<Office>(id);
        }

        public async Task<object> Add(Office office)
        {
            return await db.InsertAsync(office);

        }

        public async Task<int> Update(Office office)
        {
            return await db.UpdateAsync(office);
        }
    }
}
