using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.Application.Applications;

public interface IAtualizarClienteApplication
{
    Task AtualizarAsync(Guid id, AtualizacaoClienteInputModel inputModel);
}