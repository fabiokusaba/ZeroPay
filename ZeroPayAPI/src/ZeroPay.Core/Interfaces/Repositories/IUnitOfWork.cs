using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroPay.Core.Interfaces.Repositories;

public interface IUnitOfWork
{
    IClienteRepository Clientes { get; }
    ICarteiraRepository Carteiras { get; }
    ITransacaoRepository Transacoes { get; }
    Task BeginTransactionAsync();
    Task SaveChangesAsync();
    Task CommitAsync();
}
