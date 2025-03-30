using Messager.Messager.Services.Abstractions;

namespace Messager.Messager.Services;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly IUserRepository _userRepository;

    public MessageService(IMessageRepository messageRepository, IUserRepository userRepository)
    {
        _messageRepository = messageRepository;
        _userRepository = userRepository;
    }

    public async Task SendMessageAsync(Message message)
    {
        var senderExists = await _userRepository.UserExistsAsync(message.senderId);
        var receiverExists = await _userRepository.UserExistsAsync(message.receiverId);
        if (!senderExists || !receiverExists)
        {
            throw new ArgumentException("Sender or receiver id not found");
        }
        await _messageRepository.AddAsync(message);
    }
}