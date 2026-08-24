using Domain.Models;

namespace Aplication.Services;

/// <summary>
/// Contrato do serviço de usuários na camada de Aplicação.
/// Responsável pelas regras de negócio e casos de uso de usuários.
/// </summary>
public interface IUserService
{
    Task<List<User>> GetUsersAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User> CreateAsync(User user);
    Task<int> UpdateUserAsync(int id, User user);
    Task<int> DeleteAsync(int id);
}