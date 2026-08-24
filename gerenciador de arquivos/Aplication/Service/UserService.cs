using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.DTOs.User;
using Aplication.Interfaces;
using Domain.Interface;
using Domain.Models;
using System.Security.Cryptography;
using System.Text;

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
            using var hmac = new HMACSHA512();
            var user = new User
            {
                UserName = userPostDTO.UserName,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userPostDTO.Password))
            };

            var createdUser = await _UserReporitory.CreateAsync(user);
            return new UserGetDTO
            {
                UserName = createdUser.UserName,
                UserId = createdUser.UserId
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var DeleteAsync = await _UserReporitory.DeleteAsync(id);
            return DeleteAsync>0;
        }

        public async Task<UserGetDTO?> GetByIdAsync(int id)
        {
            var user = await _UserReporitory.GetByIdAsync(id);
            if (user is null) return null;

            return new UserGetDTO
            {
              UserName = user.UserName,
              UserId = user.UserId  
            };
        }
        public async Task<List<UserGetDTO>> GetUsersAsync()
        {
            var users = await _UserReporitory.GetUsersAsync();
            return users.Select( u => new UserGetDTO
             {                                                                                                                                              
                UserId = u.UserId,                                                                                                                         
                UserName = u.UserName                                                                                                                      
            }).ToList();   
        }

        public async Task<bool> UpdateUserAsync(int id, UserPostDTO userDto)                                                                                   
        {                                                                                                                                                      
            using var hmac = new HMACSHA512();                                                                                                                 
            var user = new User                                                                                                                                
            {                                                                                                                                                  
                UserName = userDto.UserName,                                                                                                                   
                PasswordSalt = hmac.Key,                                                                                                                       
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password))                                                                      
            };                                                                                                                                                 
                                                                                                                                                            
            var affectedRows = await _UserReporitory.UpdateUserAsync(id, user);
            return affectedRows > 0;                                                                                                                           
        }                                
    }
}