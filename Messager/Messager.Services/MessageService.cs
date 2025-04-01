using Messager.Messager.Services.Abstractions;
using Messager.Messager.UnitOfWork.Abstractions;

namespace Messager.Messager.Services;

public class MessageService : IMessageService
{
    private readonly IUnitOfWork _unitOfWork;

    public MessageService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task SendMessageAsync(Message message)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var senderExists = await _unitOfWork.UserRepository.UserExistsAsync(message.senderId);
            var recieverExists = await _unitOfWork.UserRepository.UserExistsAsync(message.receiverId);
            if (!senderExists || !recieverExists)
            {
                throw new ArgumentException("Sender or Receiver doesn't exist!");
            }

            await _unitOfWork.MessageRepository.AddAsync(message);
            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}