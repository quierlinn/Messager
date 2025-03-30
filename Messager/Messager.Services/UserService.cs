using Messager.Messager.Services.Abstractions;
using Messager.Models;

namespace Messager.Messager.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await userRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await userRepository.GetAllAsync();
    }

    public async Task RegisterUserAsync(User user)
    {
        await userRepository.AddAsync(user);
    }
}