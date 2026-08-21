using Domain.Models;

namespace Domain.Interface;

/// <summary>
/// Contrato do repositório de usuários no Domain.
/// Define os métodos de persistência sem depender de nenhuma tecnologia de banco de dados (DIP - Dependency Inversion Principle).
/// </summary>
public interface IUserRepository
{
    Task<List<User>> GetUsersAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User> CreateAsync(User user);
    Task<int> UpdateUserAsync(int id, User user);
    Task<int> DeleteAsync(int id);
}