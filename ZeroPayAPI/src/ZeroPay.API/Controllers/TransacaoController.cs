using Microsoft.AspNetCore.Mvc;
using ZeroPay.Core.Interfaces.Applications;
using ZeroPay.Core.Interfaces.Notifications;
using ZeroPay.Core.Models.InputModels;

namespace ZeroPay.API.Controllers;

public class TransacaoController(IDepositarApplication depositarApplication, INotificacao notificacao) : MainController(notificacao)
{
    [HttpPost("deposito")]
    public async Task<IActionResult> DepositarAsync([FromBody] DepositoInputModel inputModel)
    {
        var saldoResultante = await depositarApplication.DepositarAsync(inputModel);
        return RespostaPersonalizada(Ok(saldoResultante));
    }
}