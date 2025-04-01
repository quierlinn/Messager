using Messager.Data;
using Messager.Models;
using Microsoft.EntityFrameworkCore;

namespace Messager.Messager.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ChatContext context;

    public UserRepository(ChatContext context)
    {
        this.context = context;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await context.Users.AddAsync(user);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task<bool> UserExistsAsync(int id)
    {
        return await context.Users.AnyAsync(u => u.id == id);
    }
    
}