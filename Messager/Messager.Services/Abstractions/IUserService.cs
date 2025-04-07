using Messager.Models;

namespace Messager.Messager.Services.Abstractions;

public interface IUserService
{
    Task<User> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task RegisterUserAsync(User user);
}