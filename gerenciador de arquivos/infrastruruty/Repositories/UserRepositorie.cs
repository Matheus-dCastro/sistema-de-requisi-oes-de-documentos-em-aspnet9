using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interface;
using Domain.Models;
using infrastruruty.Data;
using Microsoft.EntityFrameworkCore;

namespace infrastruruty.Repositories
{
    public class UserRepositorie : UserRepository // aqui eu defino como as coisas vao acontecer no banco de dados para o modelo user

    {

        public UserRepositorie(UserDB userDbContext){
            UserDbContext = userDbContext;
        }

        public UserDB UserDbContext { get; }

        public async Task<User> CreateAsync(User user) // cria a conexao com o banco
        {
            await UserDbContext.Users.AddAsync(user); // estabelece a conexao
            await UserDbContext.SaveChangesAsync(); // salva a conexa da sessao com o user 

            return user; // retorna o user com a conxao estabelecida
        }

        public async Task<int> DeleteAsync(int id)
        {
            var user = await UserDbContext.Users.FirstOrDefaultAsync(model => model.UserId == id); // procura o user do bd

            if (user is null) // verifica se ele existe
            {
                return 0;
            }

            UserDbContext.Users.Remove(user);
            return await UserDbContext.SaveChangesAsync(); //salva as alteraçoes no banco de dados
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var user = await UserDbContext.Users.ToListAsync(); // retorna toda os user atuais do banco de dados
            return user;
        }

        public Task<List<User>> GetUsersInfosAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}