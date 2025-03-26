using Messager.Models;

namespace Messager.Data;

using Microsoft.EntityFrameworkCore;

public class ChatContext : DbContext
{
    private DbSet<User> users { get; }
    private DbSet<Message> messages { get; }
    public DbSet<User> Users => users;
    public DbSet<Message>Messages => messages;

    public ChatContext(DbContextOptions<ChatContext> options) : base(options)
    {
        
    }
}