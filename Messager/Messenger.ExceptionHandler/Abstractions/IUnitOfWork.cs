namespace Messager.Messager.UnitOfWork.Abstractions;

public interface IUnitOfWork : IDisposable
{
    public IUserRepository Users { get; }
    public IMessageRepository Messages { get; }
    Task CommitAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}