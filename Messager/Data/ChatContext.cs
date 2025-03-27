using Messager.Models;

namespace Messager.Data;

using Microsoft.EntityFrameworkCore;

public class ChatContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }

    public ChatContext(DbContextOptions<ChatContext> options) : base(options)
    {
        
    }
}