using Employee_Directory.Contracts;
using Employee_Directory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Directory.Services
{
    public class JobTitleService: IJobTitleService
    {
        private readonly PetaPoco.Database db;

        public JobTitleService(PetaPoco.Database database)
        {
            this.db = database;
        }

        public IEnumerable<JobTitle> Get()
        {
             return db.Query<JobTitle>(Constants.JobTitle.GetJobTitles);
        }

        public async Task<JobTitle> Get(int id)
        {
            return await db.SingleAsync<JobTitle>(id);
        }

        public async Task<object> Add(JobTitle jobTitle)
        {
            return await db.InsertAsync(jobTitle);
        }

        public async Task<int> Update(JobTitle jobTitle)
        {
            return await db.UpdateAsync(jobTitle);
        }
    }
}
