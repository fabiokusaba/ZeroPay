using ZeroPay.Core.Models.ViewModel;

namespace ZeroPay.Core.Interfaces.Applications;

public interface IBuscarClientePorIdApplication
{
    Task<ClienteViewModel?> BuscarPorIdAsync(Guid id);
}