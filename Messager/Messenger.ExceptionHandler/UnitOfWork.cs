using Messager.Data;
using Messager.Messager.Repositories;
using Messager.Messager.UnitOfWork.Abstractions;
using Microsoft.EntityFrameworkCore.Storage;

public class UnitOfWork : IUnitOfWork
{
    private readonly ChatContext _context;
    private IDbContextTransaction _transaction;
    private bool _disposed;
    public IUserRepository Users { get; }
    public IMessageRepository Messages { get; }

    public UnitOfWork(ChatContext context)
    {
        _context = context;
        Users = new UserRepository(context);
        Messages = new MessageRepository(context);
    }


    public bool HasActiveTransaction => _transaction != null;

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        finally
        {
            await DisposeTransactionAsync();
        }
    }

    public async Task RollbackTransactionAsync()
    {
        try
        {
            await _transaction.RollbackAsync();
        }
        finally
        {
            await DisposeTransactionAsync();
        }
    }

    private async ValueTask DisposeTransactionAsync()
    {
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public async ValueTask DisposeAsync()
    {
        if (!_disposed)
        {
            await DisposeTransactionAsync();
            await _context.DisposeAsync();
            _disposed = true;
        }

        GC.SuppressFinalize(this);
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _transaction?.Dispose();
            _context.Dispose();
            _disposed = true;
        }

        GC.SuppressFinalize(this);
    }
}