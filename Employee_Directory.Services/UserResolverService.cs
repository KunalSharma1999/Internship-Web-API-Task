using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services
{
    public class UserResolverService
    {
        private readonly ClaimsPrincipal _context;
        public UserResolverService(ClaimsPrincipal context)
        {
            _context = context;
        }

        public string GetUser()
        {
            return _context.Identity.Name;
        }
    }
}
