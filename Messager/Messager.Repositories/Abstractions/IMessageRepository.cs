using Messager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IMessageRepository
{
    Task<Message> GetByIdAsync(int id);
    Task<IEnumerable<Message>> GetAllAsync();
    Task AddAsync(Message message);
}