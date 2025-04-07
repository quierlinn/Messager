using Messager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<User> GetByUsernameAsync(string username);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    Task SaveChangesAsync();
    Task<bool> UserExistsAsync(int id);
    Task<bool> UsernameExistsAsync(string username);
}