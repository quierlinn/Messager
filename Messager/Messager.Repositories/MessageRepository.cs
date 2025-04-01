using Messager.Data;
using Microsoft.EntityFrameworkCore;

namespace Messager.Messager.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly ChatContext context;

    public MessageRepository(ChatContext context)
    {
        this.context = context;
    }
    public async Task<Message> GetByIdAsync(int id)
    {
        return await context.Messages.FindAsync(id);
    }

    public async Task<IEnumerable<Message>> GetAllAsync()
    {
        return await context.Messages.ToListAsync();
    }

    public async Task AddAsync(Message message)
    {
        await context.Messages.AddAsync(message);
    }
}