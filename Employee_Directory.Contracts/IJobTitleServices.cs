using Employee_Directory.Models;
using System.Collections.Generic;

namespace Employee_Directory.Contracts
{
    public interface IJobTitleServices
    {
        IEnumerable<JobTitle> GetJobTitles();

        void Add(JobTitle jobTitle);

        JobTitle GetJobTitle(int id);
    }
}
