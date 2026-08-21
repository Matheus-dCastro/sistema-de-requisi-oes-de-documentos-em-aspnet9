using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Services;
using Domain.Interface;
using Domain.Models;

namespace Aplication.Services
{
    public class servicesAplication : ServiceInterface
    {
        private readonly UserRepository userRepositore; // chama por referencia la do da camada de infra o user e seus metodos
        public servicesAplication(UserRepository userRepositore) // chamar o proprio objeto
        {
            this.userRepositore = userRepositore;
        }
        public async Task<User> CreateAsync(User user) // estabelece a conexao entre as camadas
        {
            return await userRepositore.CreateAsync(user); // a conexao do repositorie vem para o service da camada de aplication
        }

        public async Task<int> DeleteAsync(int id) // assim como a create as demais de baixo funcionam da mesma forma como se fosse uma ponte entre as camada
        {
            return await userRepositore.DeleteAsync(id);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await userRepositore.GetByIdAsync(id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await userRepositore.GetUsersAsync();
        }

        public async Task<List<User>> GetUsersInfosAsync()
        {
            return await userRepositore.GetUsersInfosAsync();
        }

        public async Task<int> UpdateUserAsync(int id, User user)
        {
            return await userRepositore.UpdateUserAsync(id, user);
        }
    }
}