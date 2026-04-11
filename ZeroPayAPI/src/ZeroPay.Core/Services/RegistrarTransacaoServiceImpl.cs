using ZeroPay.Core.Interfaces.Repositories;
using ZeroPay.Core.Interfaces.Services;
using ZeroPay.Core.Mappers;
using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.Core.Services;

public class RegistrarTransacaoServiceImpl(IUnitOfWork unitOfWork) : IRegistrarTransacaoService
{
    public async Task<Guid> RegistrarAsync(RegistroTransacaoInputModel inputModel)
    {
        return await unitOfWork.Transacoes.CadastrarAsync(inputModel.ToEntity());
    }
}