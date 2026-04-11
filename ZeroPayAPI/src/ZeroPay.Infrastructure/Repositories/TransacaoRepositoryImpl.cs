using ZeroPay.Core.Entities;
using ZeroPay.Core.Interfaces.Repositories;

namespace ZeroPay.Infrastructure.Repositories;

public class TransacaoRepositoryImpl(ZeroPayDbContext dbContext) : ITransacaoRepository
{
    public async Task<Guid> CadastrarAsync(Transacao transacao)
    {
        var entidade = await dbContext.Transacoes.AddAsync(transacao);
        await dbContext.SaveChangesAsync();
        return entidade.Entity.Id;
    }
}