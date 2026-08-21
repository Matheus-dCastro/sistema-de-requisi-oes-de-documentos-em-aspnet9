using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Aplication.Services
{
    public interface ServiceInterface //estou criando a parte do DTO para fazer a camada de transporte de dados entre as camadas 
    {
        Task<List<User>> GetUsersInfosAsync(); // devolve as infos de user
        Task<User> GetByIdAsync(int id); // capitura o ID do user
        Task<int> UpdateUserAsync(int id, User user); // update das informaçoes do user
        Task<User> CreateAsync(User user); // cria user
        Task<int> DeleteAsync(int id); // metodo para deleter um user do sistema
        Task<List<User>> GetUsersAsync(); // espera receber uma lista de user de algum lugar mais n se importa da onde vem
    }
}