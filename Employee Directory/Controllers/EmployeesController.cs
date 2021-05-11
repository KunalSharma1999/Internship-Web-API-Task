using Employee_Directory.Contracts;
using Employee_Directory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeServices employeeContext;
        private IDepartmentServices departmentContext;
        private IOfficeServices officeContext;
        private IJobTitleServices jobTitleContext;
        public EmployeesController
        (IEmployeeServices ec,
         IDepartmentServices dc,
         IOfficeServices oc,
         IJobTitleServices jc
        )
        {
            employeeContext = ec;
            departmentContext = dc;
            officeContext = oc;
            jobTitleContext = jc;
        }
        //Employees
        [HttpGet]
        [Route("allemployeedetails")]
        public IEnumerable<Employee> Get()
        {
            return employeeContext.GetAllEmployees();
        }

        [HttpGet]
        [Route("getemployeedetailsbyid/{id}")]
        public Employee GetEmployeeById(int id)
        {
            return employeeContext.GetEmployeeData(id);
        }

        [HttpPost]
        [Route("insertemployeedetails")]
        public void PostEmployee([FromBody] Employee employee)
        {
            employeeContext.AddEmployee(employee);
        }

        [HttpPut]
        [Route("updateemployeedetails/{id}")]
        public void PutEmployee(int id, [FromBody] Employee employee)
        {
            employeeContext.UpdateEmployee(id, employee);
        }

        //Departments
        [HttpGet]
        [Route("alldepartmentdetails")]
        public IEnumerable<Department> GetDepartments()
        {
            return departmentContext.GetAllDepartments();
        }

        [HttpGet]
        [Route("getdepartmentdetailsbyid/{id}")]
        public Department GetDepartmentById(int id)
        {
            return departmentContext.GetDepartmentById(id);
        }

        [HttpPost]
        [Route("insertdepartmentdetails")]
        public void PostDepartment([FromBody] Department department)
        {
            departmentContext.AddDepartment(department);
        }

        [HttpPut]
        [Route("updatedepartmentdetails/{id}")]
        public void PutDepartment(int id, [FromBody] Department department)
        {
            departmentContext.UpdateDepartment(id, department);
        }

        //Offices
        [HttpGet]
        [Route("allofficedetails")]
        public IEnumerable<Office> GetOffices()
        {
            return officeContext.GetAllOffices();
        }

        [HttpGet]
        [Route("getofficedetailsbyid/{id}")]
        public Office GetofficeById(int id)
        {
            return officeContext.GetOfficeById(id);
        }

        [HttpPost]
        [Route("insertofficedetails")]
        public void PostOffice([FromBody] Office office)
        {
            officeContext.AddOffice(office);
        }

        [HttpPut]
        [Route("updateofficedetails/{id}")]
        public void PutOffice(int id, [FromBody] Office office)
        {
            officeContext.UpdateOffice(id, office);
        }

        //JobTitles
        [HttpGet]
        [Route("alljobtitledetails")]
        public IEnumerable<JobTitle> GetJobTitles()
        {
            return jobTitleContext.GetAllJobTitles();
        }

        [HttpGet]
        [Route("getjobtitledetailsbyid/{id}")]
        public JobTitle GetJobTitleById(int id)
        {
            return jobTitleContext.GetJobTitleById(id);
        }

        [HttpPost]
        [Route("insertjobtitledetails")]
        public void PostJobTitle([FromBody] JobTitle jobtitle)
        {
            jobTitleContext.AddJobTitle(jobtitle);
        }

        [HttpPut]
        [Route("updatejobtitledetails/{id}")]
        public void PutJobTitle(int id, [FromBody] JobTitle jobtitle)
        {
            jobTitleContext.UpdateJobTitle(id, jobtitle);
        }
    }
}