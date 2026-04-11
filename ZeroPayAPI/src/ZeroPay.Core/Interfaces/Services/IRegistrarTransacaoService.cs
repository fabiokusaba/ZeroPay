using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.Core.Interfaces.Services;

public interface IRegistrarTransacaoService
{
    Task<Guid> RegistrarAsync(RegistroTransacaoInputModel inputModel);
}