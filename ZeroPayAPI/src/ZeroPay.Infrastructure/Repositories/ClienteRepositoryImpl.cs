using ZeroPay.Core.Entities;
using ZeroPay.Core.Interfaces.Repositories;

namespace ZeroPay.Infrastructure.Repositories;

public class ClienteRepositoryImpl(ZeroPayDbContext dbContext) : IClienteRepository
{
    private readonly ZeroPayDbContext _dbContext = dbContext;

    public async Task<Guid> CadastrarAsync(Cliente cliente)
    {
        var novoCliente = await _dbContext.Clientes.AddAsync(cliente);
        
        await _dbContext.SaveChangesAsync();

        return novoCliente.Entity.Id;
    }
}