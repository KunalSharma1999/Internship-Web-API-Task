using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Directory.Models
{
    public class EmployeeCard
    {
        public int Id { get; set; }

        public string  PreferredName { get; set; }

        public string Department { get; set; }

        public string  JobTitle { get; set; }

        public string Office { get; set; }
    }
}
