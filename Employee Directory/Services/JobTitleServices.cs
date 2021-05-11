using Employee_Directory.Contracts;
using Employee_Directory.Models;
using System;
using System.Collections.Generic;

namespace Employee_Directory.Services
{
    public class JobTitleServices: IJobTitleServices
    {
        PetaPoco.Database db = new PetaPoco.Database("Data Source=localhost;Initial Catalog=EmployeeDB;Integrated Security=True", "System.Data.SqlClient");


        public IEnumerable<JobTitle> GetAllJobTitles()
        {
            try
            {
                return db.Query<JobTitle>("Select * from Jobtitles");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddJobTitle(JobTitle jobTitle)
        {
            try
            {
                db.Insert("JobTitles", jobTitle);
            }
            catch
            {
                throw;
            }
        }

        public void UpdateJobTitle(int id, JobTitle jobTitle)
        {
            try
            {
                jobTitle.Id = id;
                db.Update("JobTitles", "Id", jobTitle);
            }
            catch
            {
                throw;
            }
        }

        public JobTitle GetJobTitleById(int id)
        {
            try
            {
                return db.SingleOrDefault<JobTitle>("SELECT * FROM JobTitles WHERE Id=@0", id);
            }
            catch
            {
                throw;
            }
        }
    }
}
