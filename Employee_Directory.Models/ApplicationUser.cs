using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Directory.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Column(TypeName="nvarchar(150)")]
        public string FullName { get; set; }
    }
}
