using Messager.Data;
using Messager.Messager.Services.Abstractions;
using Messager.Models;

namespace Messager.Messager.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly ChatContext chatContext;

    public UserService(IUserRepository userRepository, ChatContext chatContext)
    {
        this.userRepository = userRepository;
        this.chatContext = chatContext;
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
        using var transaction = await chatContext.Database.BeginTransactionAsync();
        try
        {
            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}