using AutoMapper;
using EmployeeDirectory.DataModels;
using EmployeeDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>();
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<DepartmentViewModel, Department>();
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<JobTitleViewModel, JobTitle>();
            CreateMap<JobTitle, JobTitleViewModel>();
            CreateMap<OfficeViewModel, Office>();
            CreateMap<Office, OfficeViewModel>();
        }
    }
}
