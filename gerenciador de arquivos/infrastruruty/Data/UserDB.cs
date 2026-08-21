using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace infrastruruty.Data
{
    public class UserDB : DbContext
    {
        public UserDB(DbContextOptions<DbContext> dbContextOptions) : base(dbContextOptions) // assim a ref pode herdar todas as propriedades e consegue fazer tanto acesso de leitura e escrita para o banco
        {}
        public DbSet<User> GetUsers{get; set;}
    }
}