using Microsoft.EntityFrameworkCore;
using NetCoreReact.Core.Interfaces;
using NetCoreReact.Core.Models;
using NetCoreReact.Data.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreReact.Core.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserModel> AuthentificateUserAsync(string email, string password)
        {
            var userEntity = await userRepository.AuthentificateUserAsync(email, password);

            if (userEntity is null) return null;

            return new UserModel
            {
                Id = userEntity.Id,
                Username = userEntity.Username,
                Email = userEntity.Email,
                Password = userEntity.Password,
            };
        }

        public async Task<UserModel> CreateUserAsync(UserModel userModel)
        {
            if (userModel is null)
            {
                throw new ArgumentNullException(nameof(userModel));
            }

            if (userRepository.Get().Any(u => u.Email == userModel.Email))
            {
                throw new ArgumentException("Forbidden to register User with an existing Email");
            }

            var userEntity = new Data.Entities.User
            {
                Username = userModel.Username,
                Email = userModel.Email,
                Password = userModel.Password,
            };

            userEntity = await userRepository.AddAsync(userEntity);

            return new UserModel
            {
                Id = userEntity.Id,
                Username = userEntity.Username,
                Email = userEntity.Email,
                Password = userEntity.Password,
            };
        }

        public async Task<UserModel> GetUserAsync(Guid userId)
        {
            var userEntity = await userRepository.FindAsync(userId);

            if (userEntity is null) return null;

            return new UserModel
            {
                Id = userEntity.Id,
                Username = userEntity.Username,
                Email = userEntity.Email,
                Password = userEntity.Password,
                Events = userEntity.Events.Select(e => new EventModel
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    AllDay = e.AllDay,
                    Place = e.Place
                }).ToList()
            };
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            IQueryable<Data.Entities.User> query = userRepository.Get();
            return await query.Select(userEntity => new UserModel
            {
                Id = userEntity.Id,
                Username = userEntity.Username,
                Email = userEntity.Email,
                Password = userEntity.Password,
                //Events = userEntity.Events 
            }).ToListAsync();
        }

        public Task<UserModel> UpdateUserAsync(UserModel userModel)
        {
            throw new NotImplementedException();
        }
        public Task DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
