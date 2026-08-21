using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interface;

public interface UserRepository
{
    Task<List<User>> GetUsersAsync(); // espera receber uma lista de user de algum lugar mais n se importa da onde vem
    Task<User> GetByIdAsync(int id); // capitura o ID do user
    Task<User> CreateAsync(User user); // cria user
    Task<int> UpdateAsync(int id, User user); // update das informaçoes do user
    Task<int> DeleteAsync(int id); // metodo para deleter um user do sistema
    Task<List<User>> GetUsersInfosAsync(User user); // devolve as infos de user
}