namespace Messager.Messager.UnitOfWork.Abstractions;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IMessageRepository MessageRepository { get; }
    Task<int>CommitAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}