using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.DTOs.User;

namespace Aplication.Interfaces
{
    public interface IUserService
    {
        Task<List<UserGetDTO>> GetUsersAsync();
        Task<UserGetDTO?> GetByIdAsync(int id);
        Task<UserGetDTO> CreateAsync(UserPostDTO user);
        Task<bool> UpdateUserAsync(int id, UserPostDTO user);
        Task<bool> DeleteAsync(int id);

        Task<bool> VerifyPasswordAsync(string password, byte[] salt, byte[] hash);
    }
}