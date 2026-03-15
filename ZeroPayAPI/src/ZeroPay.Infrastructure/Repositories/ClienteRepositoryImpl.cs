using Microsoft.EntityFrameworkCore;
using ZeroPay.Core.Entities;
using ZeroPay.Core.Interfaces.Repositories;

namespace ZeroPay.Infrastructure.Repositories;

public class ClienteRepositoryImpl(ZeroPayDbContext dbContext) : IClienteRepository
{
    public async Task<Guid> CadastrarAsync(Cliente cliente)
    {
        var novoCliente = await dbContext.Clientes.AddAsync(cliente);
        
        await dbContext.SaveChangesAsync();

        return novoCliente.Entity.Id;
    }

    public async Task<IEnumerable<Cliente>> BuscarAsync()
    {
        var clientes = await dbContext.Clientes.ToListAsync();
        return clientes;
    }

    public async Task<Cliente?> BuscarPorIdAsync(Guid id)
    {
        var cliente = await dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        return cliente;
    }

    public Task SaveChangesAsync()
    {
        return dbContext.SaveChangesAsync();
    }
}