using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XandaDeck.Data.Entities;
using XandaDeck.Data.Models;

namespace XandaDeck.Core.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetCurrentUser();
        Task<string> RegisterAsync(RegisterModel model);
        Task<AuthenticationModel> GetTokenAsync(TokenRequest tokenRequest); 
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<AuthenticationModel> RefreshTokenAsync(string jwtToken);
        bool RevokeToken(string token);
        ApplicationUser GetById(string id);
    }
}
