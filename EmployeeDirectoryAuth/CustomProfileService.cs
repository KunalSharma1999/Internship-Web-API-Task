using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDirectoryAuth.Data;
using System.Security.Claims;
using IdentityModel;

namespace EmployeeDirectoryAuth
{
    public class CustomProfileService : IProfileService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CustomProfileService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            { 
                var subjectId = context.Subject.GetSubjectId();
                var user = _applicationDbContext.Users.Where(u => u.Id == subjectId).FirstOrDefault();
                var userClaims = _applicationDbContext.UserClaims.Where(user => user.UserId == subjectId);

                List<Claim> claims = new List<Claim>();

                foreach(Microsoft.AspNetCore.Identity.IdentityUserClaim<string> claim in userClaims)
                {
                    var claimType = claim.ClaimType;
                    var claimValue = claim.ClaimValue;

                    claims.Add(new Claim(claimType, claimValue));

                }
                context.IssuedClaims = claims;
                return Task.FromResult(0);
            }
		    catch (Exception)
            {
			    return Task.FromResult(0);
		    }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var subjectId = context.Subject.GetSubjectId();
            var user = _applicationDbContext.Users.Where(u => u.Id == subjectId).FirstOrDefault();
            context.IsActive = (user != null);
            return Task.FromResult(0);
        }
    }
}
