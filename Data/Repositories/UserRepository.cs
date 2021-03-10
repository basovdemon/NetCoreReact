using NetCoreReact.Data.Entities;
using NetCoreReact.Data.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreReact.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly EventsAppDbContext dbContext;

        public UserRepository(EventsAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> AddAsync(User user)
        {
            user.Id = user.Id == Guid.Empty ? Guid.NewGuid() : user.Id;
            dbContext.Add(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> AuthentificateUserAsync(string email, string password)
        {
            return await dbContext.Users.FindAsync(email, password);
        }

        public async Task<User> FindAsync(Guid id)
        {
            return await dbContext.Users.FindAsync(id);
        }

        public IQueryable<User> Get()
        {
            return dbContext.Users.AsQueryable();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}