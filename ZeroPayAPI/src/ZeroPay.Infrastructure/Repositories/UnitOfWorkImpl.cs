using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using ZeroPay.Core.Interfaces.Repositories;

namespace ZeroPay.Infrastructure.Repositories;

public class UnitOfWorkImpl(
    ZeroPayDbContext zeroPayDbContext,
    IClienteRepository clientes,
    ICarteiraRepository carteiras,
    ITransacaoRepository transacoes
) : IUnitOfWork
{

    private IDbContextTransaction? _transaction; // Armazena os dados da transação que está sendo efetuada.
    public IClienteRepository Clientes => clientes;
    public ICarteiraRepository Carteiras => carteiras;
    public ITransacaoRepository Transacoes => transacoes;

    public async Task BeginTransactionAsync()
    {
        _transaction = await zeroPayDbContext.Database.BeginTransactionAsync();
    }

    public async Task SaveChangesAsync()
    {
        await zeroPayDbContext.SaveChangesAsync();
    }

    public async Task CommitAsync()
    {
        if (_transaction is null)
            throw new Exception("Nenhuma transação iniciada");

        try
        {
            await _transaction.CommitAsync();
        }
        catch (Exception)
        {
            await _transaction.RollbackAsync();
            throw;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            zeroPayDbContext.Dispose();
    }
}
