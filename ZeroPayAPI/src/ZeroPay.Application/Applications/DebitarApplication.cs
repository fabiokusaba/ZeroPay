using System.Net;
using ZeroPay.Core.Interfaces.Applications;
using ZeroPay.Core.Interfaces.Notifications;
using ZeroPay.Core.Interfaces.Repositories;
using ZeroPay.Core.Interfaces.Services;
using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.Application.Applications;

public class DebitarApplication(
    IUnitOfWork unitOfWork, 
    IRegistrarTransacaoService registrarTransacaoService, 
    INotificacao notificacao) : IDebitarApplication
{
    public async Task<decimal> DebitarAsync(DebitoInputModel inputModel)
    {
        var carteira = await unitOfWork.Carteiras.BuscarPorIdAsync(inputModel.CarteiraId);

        if (carteira is null)
        {
            notificacao.Handle(
                $@"Não foi possível encontrar nenhuma carteira com id ""{inputModel.CarteiraId}"".", 
                HttpStatusCode.NotFound
            );
            
            return 0m;
        }

        var valorAbsolutoDebito = Math.Abs(inputModel.Valor);

        if (valorAbsolutoDebito > carteira.Saldo)
        {
            notificacao.Handle(
                $"Esta operação não pode ser realizada, saldo insuficiente! Saldo atual: R$ {carteira.Saldo}", 
                HttpStatusCode.BadRequest
            );
            
            return 0m;
        }

        var saldoResultante = carteira.Saldo - valorAbsolutoDebito;

        var transacao = new RegistroTransacaoInputModel(
            inputModel.Tipo, 
            valorAbsolutoDebito * -1, 
            inputModel.Descricao,
            inputModel.CarteiraId, 
            saldoResultante
        );

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