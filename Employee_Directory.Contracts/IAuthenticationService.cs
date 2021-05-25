using Employee_Directory.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Employee_Directory.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> Register(ApplicationUserModel model);

        Task<string> Login(LoginModel model);
    }
}
