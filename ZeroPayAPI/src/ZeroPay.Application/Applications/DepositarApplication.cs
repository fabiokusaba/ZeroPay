using System.Net;
using ZeroPay.Core.Enums;
using ZeroPay.Core.Interfaces.Applications;
using ZeroPay.Core.Interfaces.Notifications;
using ZeroPay.Core.Interfaces.Repositories;
using ZeroPay.Core.Interfaces.Services;
using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.Application.Applications;

public class DepositarApplication(IUnitOfWork unitOfWork, IRegistrarTransacaoService registrarTransacaoService, INotificacao notificacao) : IDepositarApplication
{
    public async Task<decimal> DepositarAsync(DepositoInputModel inputModel)
    {
        var carteira = await unitOfWork.Carteiras.BuscarPorIdAsync(inputModel.CarteiraId);

        if (carteira is null)
        {
            notificacao.Handle($@"Não foi encontrada nenhuma carteira com o id ""{inputModel.CarteiraId}"".", HttpStatusCode.NotFound);
            return 0m;
        }

        var saldoResultante = carteira.Saldo + inputModel.Valor;

        var transacao = new RegistroTransacaoInputModel(ETipoTransacao.Deposito, inputModel.Valor, inputModel.Descricao,
            inputModel.CarteiraId, saldoResultante);

        try
        {
            await unitOfWork.BeginTransactionAsync();
            await registrarTransacaoService.RegistrarAsync(transacao);
            carteira.AtualizarSaldo(saldoResultante);
            await unitOfWork.SaveChangesAsync();
            await unitOfWork.CommitAsync();
            return saldoResultante;
        }
        catch (Exception)
        {
            throw;
        }
    }
}