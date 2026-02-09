using ZeroPay.Core.Interfaces.Applications;
using ZeroPay.Core.Interfaces.Repositories;
using ZeroPay.Core.Mappers;
using ZeroPay.Core.Models.ViewModel;

namespace ZeroPay.Application.Applications;

public class BuscarClientesApplication(IClienteRepository clienteRepository) : IBuscarClientesApplication
{
    public async Task<IEnumerable<ClienteViewModel>> BuscarAsync()
    {
        var clientes = await clienteRepository.BuscarAsync();
        return clientes.Select(c => c.ToViewModel());
    }
}