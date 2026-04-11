using ZeroPay.Core.Entities;

namespace ZeroPay.Core.Interfaces.Repositories;

public interface ITransacaoRepository
{ 
    Task<Guid> CadastrarAsync(Transacao transacao);
}