using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<Cliente>> BuscarAsync()
    {
        var clientes = await _dbContext.Clientes.ToListAsync();
        return clientes;
    }

    public async Task<Cliente?> BuscarPorIdAsync(Guid id)
    {
        var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        return cliente;
    }
}