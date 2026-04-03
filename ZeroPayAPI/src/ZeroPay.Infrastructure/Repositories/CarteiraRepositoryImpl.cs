using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeroPay.Core.Entities;
using ZeroPay.Core.Interfaces.Repositories;

namespace ZeroPay.Infrastructure.Repositories;

public class CarteiraRepositoryImpl(ZeroPayDbContext zeroPayDbContext) : ICarteiraRepository
{
    public async Task<Guid> CadastrarAsync(Carteira carteira)
    {
        var entidade = await zeroPayDbContext.AddAsync(carteira);
        await zeroPayDbContext.SaveChangesAsync();
        return entidade.Entity.Id;
    }
}
