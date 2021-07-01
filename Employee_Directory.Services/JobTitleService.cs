using EmployeeDirectory.Contracts;
using EmployeeDirectory.DataModels;
using EmployeeDirectory.Models;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services
{
    public class JobTitleService: IJobTitleService
    {
        private readonly PetaPoco.Database db;

        private AutoMapper.IMapper mapper;

        public JobTitleService(PetaPoco.Database database, AutoMapper.IMapper mapper)
        {
            this.db = database;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<JobTitleViewModel>> Get()
        {
            var jobTitles = await db.FetchAsync<JobTitle>();
            var jobs = mapper.Map<IEnumerable<JobTitleViewModel>>(jobTitles);
            return jobs;
        }

        public async Task<JobTitleViewModel> Get(int id)
        {
            var jobTitle = await db.SingleAsync<JobTitle>(id);
            var job = mapper.Map<JobTitleViewModel>(jobTitle);
            return job;
        }

        public Task<object> Add(JobTitleViewModel jobTitle)
        {
            var job = mapper.Map<JobTitle>(jobTitle);
            job.CreatedOn = DateTime.Now;
            job.ModifiedOn = DateTime.Now;
            return db.InsertAsync(job);
        }

        public Task<int> Update(JobTitleViewModel jobTitle)
        {
            var job = mapper.Map<JobTitle>(jobTitle);
            var jb = db.SingleAsync<JobTitle>(job.Id);
            job.CreatedOn = jb.Result.CreatedOn;
            job.ModifiedOn = DateTime.Now;
            return db.UpdateAsync(jobTitle);
        }
    }
}
