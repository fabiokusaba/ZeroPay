using ZeroPay.Core.Entities;
using ZeroPay.Core.Models.ViewModel;

namespace ZeroPay.Core.Mappers;

public static class ClienteMapper
{
    public static ClienteViewModel ToViewModel(this Cliente cliente)
    {
        return new ClienteViewModel(cliente.Id, cliente.NomeCompleto, cliente.DataNascimento);
    }
}