using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interface;
using Domain.Models;

namespace infrastruruty.Repositories
{
    public class UserRepositorie : UserRepository // aqui eu defino como as coisas vao acontecer no banco de dados para o modelo user

    {
        public Task<User> CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsersInfosAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}