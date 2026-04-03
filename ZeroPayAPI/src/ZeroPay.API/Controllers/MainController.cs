using Microsoft.AspNetCore.Mvc;
using ZeroPay.Core.Interfaces.Notifications;
using ZeroPay.Core.Models.ViewModel;

namespace ZeroPay.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MainController(INotificacao notificacao) : ControllerBase
{
    protected readonly INotificacao _notificacao = notificacao;

    // Utilizado em todos os retornos das controllers para a gente forçar a operação de validar a operação
    // e retornar ao usuário as notificações.
    protected ActionResult RespostaPersonalizada(ActionResult actionResult)
    {
        // Cenário 1. Operação válida
        if (OperacaoValida())
            return actionResult;

        // Cenário 2. Operação inválida
        var notificacoes = _notificacao.ObterNotificacoes();

        return new JsonResult(new RespostaPadraoViewModel(
            notificacoes.Select(n => n.Mensagem)
        ))
        {
            StatusCode = (int)notificacoes[0].StatusCode
        };
    }

    // TemNotificacoes => algo aconteceu então significa que a operação é inválida.
    // Não TemNotificacoes => deu tudo certo, operação válida.
    private bool OperacaoValida() => !_notificacao.TemNotificacoes();
}