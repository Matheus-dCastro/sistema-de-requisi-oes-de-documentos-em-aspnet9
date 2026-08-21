using Domain.Interface;
using Domain.Models;

namespace Aplication.Services;

/// <summary>
/// Implementação do serviço de usuários na camada de Aplicação.
/// Orquestra a execução das regras de negócio e chama a abstração do repositório (IUserRepository).
/// </summary>
public class UserService : IUserService
{
    // Injeção de dependência da abstração do repositório (Interface do Domínio)
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateAsync(User user)
    {
        // Aqui podem entrar validações de negócio antes de persistir (ex: checar duplicidade, validar senha, etc.)
        return await _userRepository.CreateAsync(user);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _userRepository.GetUsersAsync();
    }

    public async Task<int> UpdateUserAsync(int id, User user)
    {
        return await _userRepository.UpdateUserAsync(id, user);
    }
}