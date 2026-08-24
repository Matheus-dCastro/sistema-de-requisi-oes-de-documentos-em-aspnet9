using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.DTOs.User;
using Aplication.Interfaces;
using Domain.Interface;
using Domain.Models;

namespace Aplication.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserReporitory;

        public UserService(IUserRepository userReporitory)
        {
            _UserReporitory = userReporitory;
        }

        public async Task<UserGetDTO> CreateAsync(UserPostDTO userPostDTO)
        {
            var CreateUser = new User
            {
                UserName = userPostDTO.UserName,
            };
            var createdUser = await _UserReporitory.CreateAsync(CreateUser); 
            return new UserGetDTO
            {
                UserName = createdUser.UserName,
                UserId = createdUser.UserId
            };
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserGetDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserGetDTO>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateUserAsync(int id, UserPostDTO user)
        {
            throw new NotImplementedException();
        }
    }
}