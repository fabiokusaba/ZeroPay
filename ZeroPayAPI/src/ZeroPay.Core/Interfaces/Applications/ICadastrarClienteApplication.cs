using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.Core.Interfaces.Applications;

public interface ICadastrarClienteApplication
{
    Task<Guid> CadastrarAsync(ClienteInputModel inputModel);
}