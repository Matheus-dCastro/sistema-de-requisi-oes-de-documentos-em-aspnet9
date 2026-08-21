using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace infrastruruty.Data;

/// <summary>
/// Contexto do Entity Framework Core para gerenciamento da base de dados.
/// </summary>
public class UserDB : DbContext
{
    // Construtor que recebe as opções de configuração (como ConnectionString) injetadas pelo container de DI
    public UserDB(DbContextOptions<UserDB> options) : base(options)
    {
    }

    // Mapeamento da tabela de Usuários
    public DbSet<User> Users { get; set; }
}