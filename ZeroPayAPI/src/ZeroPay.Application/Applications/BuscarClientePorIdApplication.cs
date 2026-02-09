using ZeroPay.Core.Interfaces.Applications;
using ZeroPay.Core.Interfaces.Repositories;
using ZeroPay.Core.Mappers;
using ZeroPay.Core.Models.ViewModel;

namespace ZeroPay.Application.Applications;

public class BuscarClientePorIdApplication(IClienteRepository clienteRepository) : IBuscarClientePorIdApplication
{
    public async Task<ClienteViewModel?> BuscarPorIdAsync(Guid id)
    {
        var cliente = await clienteRepository.BuscarPorIdAsync(id);
        return cliente?.ToViewModel();
    }
}