using Domain.Interface;
using Domain.Models;
using infrastruruty.Data;
using Microsoft.EntityFrameworkCore;

namespace infrastruruty.Repositories;

/// <summary>
/// Implementação do repositório de usuários com EF Core na camada de Infraestrutura.
/// Implementa o contrato IUserRepository definido no Domínio.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly UserDB _context;

    public UserRepository(UserDB context)
    {
        _context = context;
    }

    public async Task<User> CreateAsync(User user)
    {
        // Rastreia a nova entidade no ChangeTracker
        await _context.Users.AddAsync(user);
        
        // Executa a transação no banco gerando o comando SQL INSERT
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

        if (user is null)
        {
            return 0; // Nenhum registro encontrado para deletar
        }

        _context.Users.Remove(user);
        return await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        // AsNoTracking otimiza consultas somente-leitura evitando overhead de rastreamento no EF Core
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserId == id);
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _context.Users.AsNoTracking().ToListAsync();
    }

    public async Task<int> UpdateUserAsync(int id, User user)
    {
        // ExecuteUpdateAsync executa o UPDATE diretamente no banco sem precisar carregar a entidade em memória
        // Atualizamos apenas as colunas mutáveis (UserName e Password), preservando a Chave Primária (UserId)
        var affectedRows = await _context.Users
            .Where(u => u.UserId == id)
            .ExecuteUpdateAsync(setter => setter
                .SetProperty(u => u.UserName, user.UserName)
                .SetProperty(u => u.Password, user.Password)
            );

        return affectedRows;
    }
}
