using ZeroPay.Core.Entities;
using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.Core.Mappers;

public static class TransacaoMapper
{
    public static Transacao ToEntity(this RegistroTransacaoInputModel inputModel)
    {
        return new Transacao(
            inputModel.TipoTransacao, 
            inputModel.Valor, 
            inputModel.Descricao,
            inputModel.CarteiraId, 
            inputModel.SaldoResultante,
            inputModel.CofrinhoId
        );
    }
}