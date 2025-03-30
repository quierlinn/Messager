using Messager.Models;

namespace Messager.Messager.Services.Abstractions;

public interface IUserService
{

    public Task<User> GetByIdAsync(int id);

    public Task<IEnumerable<User>> GetAllAsync();

    public Task RegisterUserAsync(User user);
}