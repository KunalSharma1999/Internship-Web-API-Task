using Employee_Directory.Models;
using System.Collections.Generic;

namespace Employee_Directory.Contracts
{
    public interface IJobTitleServices
    {
        IEnumerable<JobTitle> GetAllJobTitles();
        void AddJobTitle(JobTitle jobTitle);
        void UpdateJobTitle(int id, JobTitle jobTitle);
        JobTitle GetJobTitleById(int id);
    }
}
