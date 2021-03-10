
using NetCoreReact.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreReact.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> CreateUserAsync(UserModel userModel);
        Task<UserModel> UpdateUserAsync(UserModel userModel);
        Task DeleteUserAsync(Guid userId);
        Task<UserModel> GetUserAsync(Guid userId);
        Task<UserModel> AuthentificateUserAsync(string email, string password);
        Task<List<UserModel>> GetUsersAsync();
    }
}
