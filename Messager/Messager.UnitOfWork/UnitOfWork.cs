using Messager.Data;
using Messager.Messager.Repositories;
using Messager.Messager.UnitOfWork.Abstractions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Messager.Messager.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ChatContext _chatContext;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(ChatContext chatContext)
    {
        _chatContext = chatContext;
        UserRepository = new UserRepository(chatContext);
        MessageRepository = new MessageRepository(chatContext);
    }

    public IUserRepository UserRepository { get; }
    public IMessageRepository MessageRepository { get; }

    public async Task<int> CommitAsync()
    {
        return await _chatContext.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _chatContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await _chatContext.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        finally
        {
            await _transaction.DisposeAsync();
        }
    }

    public async Task RollbackTransactionAsync()
    {
        await _transaction.RollbackAsync();
        await _transaction.DisposeAsync();
    }

    public void Dispose()
    {
        _chatContext.Dispose();
        _transaction?.Dispose();
    }
}