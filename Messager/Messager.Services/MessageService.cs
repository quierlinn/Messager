using Messager.Messager.Services.Abstractions;
using Messager.Messager.UnitOfWork.Abstractions;
using Messager.Messager.UnitOfWork.CustomExceptions;

public class MessageService : IMessageService
{
    private readonly IUnitOfWork _unitOfWork;

    public MessageService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task SendMessageAsync(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        var senderExists = await _unitOfWork.Users.UserExistsAsync(message.senderId);
        if (!senderExists)
        {
            throw new UserNotFoundException($"User {message.senderId} not found");
        }
        var receiverExists = await _unitOfWork.Users.UserExistsAsync(message.receiverId);
        if (!receiverExists)
        {
            throw new UserNotFoundException($"User {message.receiverId} not found");
        }
        await _unitOfWork.Messages.AddAsync(message);
        await _unitOfWork.CommitAsync();
    }
}