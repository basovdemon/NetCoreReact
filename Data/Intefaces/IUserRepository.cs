using System;
using NetCoreReact.Data.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreReact.Data.Intefaces
{
    public interface IUserRepository
    {
        Task<User> AuthentificateUserAsync(string email, string password);
        Task<User> FindAsync(Guid id);
        Task<User> UpdateAsync(User user);
        Task<User> AddAsync(User user);
        Task RemoveAsync(Guid id);
        IQueryable<User> Get();
    }
}
