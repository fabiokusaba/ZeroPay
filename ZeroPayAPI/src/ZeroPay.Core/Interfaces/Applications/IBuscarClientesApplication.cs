using ZeroPay.Core.Models.ViewModel;

namespace ZeroPay.Core.Interfaces.Applications;

public interface IBuscarClientesApplication
{
    Task<IEnumerable<ClienteViewModel>> BuscarAsync();
}