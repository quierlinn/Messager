namespace Messager.Messager.Services.Abstractions;

public interface IMessageService
{
    public Task SendMessageAsync(Message message);
}