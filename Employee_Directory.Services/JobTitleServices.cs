using Employee_Directory.Contracts;
using Employee_Directory.Models;
using System;
using System.Collections.Generic;

namespace Employee_Directory.Services
{
    public class JobTitleServices: IJobTitleServices
    {
        private readonly PetaPoco.Database db = new PetaPoco.Database("Data Source=localhost;Initial Catalog=EmployeeDB;Integrated Security=True", "System.Data.SqlClient");

        public IEnumerable<JobTitle> GetJobTitles()
        {
            try
            {
                return db.Query<JobTitle>(Constants.JobTitle.GetJobTitles);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(JobTitle jobTitle)
        {
            try
            {
                if(jobTitle != null)
                {
                    if(jobTitle.Id != default(int))
                    {
                        db.Update(Constants.JobTitle.TableName , Constants.JobTitle.PrimaryKeyName, jobTitle);
                    }
                    else
                    {
                        db.Insert(Constants.JobTitle.TableName, jobTitle);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public JobTitle GetJobTitle(int id)
        {
            try
            {
                return db.SingleOrDefault<JobTitle>(Constants.JobTitle.GetJobTitle, id);
            }
            catch
            {
                throw;
            }
        }
    }
}
